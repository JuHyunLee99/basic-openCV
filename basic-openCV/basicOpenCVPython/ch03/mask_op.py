import sys
import cv2

# 마스크 영상을 이용한 영상 합성
src1 = cv2.imread('./ch02/airplane.bmp', cv2.IMREAD_COLOR)
mask1 = cv2.imread('./ch02/mask_plane.bmp', cv2.IMREAD_GRAYSCALE)
dst1 = cv2.imread('./ch02/field.bmp', cv2.IMREAD_COLOR)

# # dst = cv2.copyTo(src, mask)
# cv2.copyTo(src, mask, dst)

dst1[mask1 > 0] = src1[mask1 > 0]

cv2.imshow('src1', src1)
cv2.imshow('dst1', dst1)
cv2.imshow('mask1', mask1)

src2= cv2.imread('./ch02/opencv-logo-white.png', cv2.IMREAD_UNCHANGED)
mask2 = src2[:, :, -1]
src2 = src2[:, :, 0:3]
dst2 = cv2.imread('./ch02/field.bmp', cv2.IMREAD_COLOR)

h, w = src2.shape[:2]
crop = dst2[10:h+10, 10:w+10]

cv2.copyTo(src2, mask2, crop)   # 모두 h,w 같아야함. src2,crop는 채널수가 같아야함.

cv2.imshow('src2', src2)
cv2.imshow('mask2', mask2)
cv2.imshow('dst2', dst2)

cv2.waitKey()
cv2.destroyAllWindows()