import cv2
import sys
print('Hello, OpenCV', cv2.__version__)

img = cv2.imread('./ch01/cat.bmp', cv2.IMREAD_GRAYSCALE)
# 영상 파일 불러오기 옵션 플래그
# cv2.IMREAD_COLOR 기본값
# cv2.IMREAD_GRAYSCALE
# cv2.IMREAD_UNCHANGED : 영상 파일 속성 그대로 읽기(투명한 PNG파일) 4채널

if img is None:
    print('Image load fail')
    sys.exit()

cv2.imwrite('./ch01/cat_gray.png', img)

#cv2.namedWindow('image')    # 생략가능. imshow바로 됨.
# 창 속성 지정 플래그F
#cv2.WINDOW_NORMAL
#cv2.WINDOW_AUTOSIZE(기본값) : 사진의 크기에 맞게 창의 크기를 생성

cv2.imshow('image', img) # img의 타입은 uint8
#cv2.waitKey(3000)   # 3초 있다가 창 꺼짐.

while True:
    if cv2.waitKey() == ord('q'):
        break

cv2.destroyWindow('image') # 특정창 닫기
# cv2.destroyAllWindows() # 모든창 닫기