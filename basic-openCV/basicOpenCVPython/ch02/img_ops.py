import cv2
import numpy as np

# 새 영상 생성하기
# img1 = np.empty((240, 320), dtype = np.uint8)  # grayscale image   # 픽셀: 임의의 값
# img2 = np.zeros((240, 320, 3), dtype = np.uint8)    # color image # 픽셀 0값
# #img3 = np.ones((240, 320, 3), dtype = np.uint8)    # color image # 픽셀 1값
# img3 = np.ones((240, 320, 3), dtype = np.uint8) * 255   # color image # 픽셀 255값
# img4 = np.full((240, 320), 128, dtype = np.uint8)    # grayscale image # 픽셀 128값

img1 = cv2.imread('./ch02/HappyFish.jpg')

img2 = img1[40:120, 30:150] # 참조
img3 = img1[40:120, 30:150].copy()  # 완전한 복사본

#img1[:,:] = (0, 255, 255)
#img2.fill(0)
cv2.circle(img2, (50, 50), 20, (0, 0, 255), 2)

cv2.imshow('img1', img1)
cv2.imshow('img2', img2)
cv2.imshow('img3', img3)
# cv2.imshow('img4', img4)
cv2.waitKey()
cv2.destroyAllWindows()