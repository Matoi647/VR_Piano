import cv2
import mediapipe as mp
import socket


mp_drawing = mp.solutions.drawing_utils
mp_hands = mp.solutions.hands
hands = mp_hands.Hands(
        static_image_mode=False,
        max_num_hands=2,
        min_detection_confidence=0.75,
        min_tracking_confidence=0.75)

width, heigth = 1280,720
cap = cv2.VideoCapture(1)
cap.set(3, width)
cap.set(4, heigth)

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)   # todo 使用UDP
serverAddressPort = ('127.0.0.1',9090)

while True:
    ret,frame = cap.read()
    results = hands.process(frame)
    w, h ,c = frame.shape
    mylmList = []
    data = []

    if results.multi_hand_landmarks:
        for hand_landmarks in results.multi_hand_landmarks:
            for id, lm in enumerate(hand_landmarks.landmark):
                px,py,pz = int(lm.x * w),int(lm.y * h),int(lm.z * 1000)
                mylmList.append([px,py,pz])

            mp_drawing.draw_landmarks(frame, hand_landmarks, mp_hands.HAND_CONNECTIONS)
        for lm in mylmList:
            data.extend([lm[0], heigth - lm[1], lm[2]])

        sock.sendto(str.encode(str(data)), serverAddressPort)
    cv2.imshow('MediaPipe Hands', frame)
    if cv2.waitKey(1)&0xFF==27:
         break
cap.release()