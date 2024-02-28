import glob
import sys
import cv2

img_files = glob.glob('.\\ch01\\images\\*.jpg')

if not img_files:
    print("There are no jpg files in 'images' folder")
    sys.exit()
    
# 전체 화면으로 'image' 창 생성
cv2.namedWindow('image', cv2.WINDOW_NORMAL)
cv2.setWindowProperty('image', cv2.WND_PROP_FULLSCREEN, cv2.WINDOW_FULLSCREEN)

cnt = len(img_files)
idx = 0

while True:
    img = cv2.imread(img_files[idx])
    
    cv2.imshow('image', img)

    if cv2.waitKey(1000) == 27: # ESC
        break

    idx += 1
    if idx >= cnt:
        idx = 0

cv2.destroyAllWindows()