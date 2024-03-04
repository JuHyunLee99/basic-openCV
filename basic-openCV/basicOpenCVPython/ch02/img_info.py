import cv2
import sys

# 영상 불러오기
img1 = cv2.imread('./ch02/cat.bmp', cv2.IMREAD_GRAYSCALE)
img2 = cv2.imread('./ch02/cat.bmp', cv2.IMREAD_COLOR)

if img1 is None or img2 is None:
    print('Image load failed!')
    sys.exit()

print(type(img1))   # numpy.ndarray
print(img1.shape)   # (h,w)
print(img2.shape)   # 각 차원의 크기 (h,w,3)
print(img1.dtype)
print(img2.dtype)   # 원소의 데이터 타입. 영상 데이터는 uinit8

if img1.ndim == 2:  # ndim: 차원수
    print('img1 is a graycale image')
if len(img1.shape) == 2:
    print('img1 is a grayscale image')

h, w = img2.shape[:2]
print('w x h = {} x {}'.format(w, h))

# 인덱싱으로 픽셀값 참조, 설정
x = 20
y = 10
p1 = img1[y, x] 
print(p1)

p2 = img2[y, x]
print(p2)

# 실제로는 이런 코드 쓰면 안됨. 매우 느림.
'''
for y in range(h):
    for x in range(w):
        img1[y, x] = 0
        img2[y, x] = (0, 255, 255)
'''
# 결과는 동일하지만 더 빠름.
img1[:,:] = 0
img2[:, :] = (0, 255, 255)

cv2.imshow('img1', img1)
cv2.imshow('img2', img2)

cv2.waitKey()

cv2.destroyAllWindows()