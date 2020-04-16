Báo cáo chi tiết Bài 1.11 TH1

Người thực hiện : Nguyễn Hữu Hoàng
MSSV : 18520283

Mục tiêu : tìm cách phân công tốt nhất sao cho thời gian làm việc là bé nhất.

Thư mục gồm có 2 file:
	- file code.py : lưu mà nguồn chương trình
	- file test.txt : chứa các dữ liệu đầu vào

File test.txt có định dạng như sau:
	- dòng đầu tiên gồm 2 số nguyên n, m với:
		+ n là số công việc
		+ m là số máy
	- Tiếp theo đó là m dòng với mỗi dòng gồm n số đại diện cho năng suất làm việc của máy 
Lưu ý : nếu file test không được định dạng như trên thì chương trình sẽ bị lỗi hoặc không có được kết quả mong muốn

Giải thuật để giải quyết bài toán:

Ở đây em áp dụng 2 phương pháp là tham lam và thứ tự để giải bài toán:
	- Đầu tiên em đánh mã cho máy từ 0 -> m - 1
	- Lần lượt theo tứ tự các mã máy từ bé đến lớn em phân như sau : 
		+ Tìm công việc mà máy đó làm nhanh nhất
		+ Nếu công việc đó không có trong danh sach công việc đã làm thì giao công việc đó cho máy đó rồi phân công cho máy khác
		+ Nếu công việc đã có trong danh sách công việc đã làm thì loại công việc đó ra khỏi danh sách công việc có thể làm của máy
		+ Tiếp tục tìm công việc chưa được làm mà máy làm nhanh nhất
		+ Nếu hết công việc có thể làm mà vẫn không tìm được thì dừng chương trình

Để chạy code, thầy/bạn có thể làm như sau :
	- Dùng bất kỳ trình soạn thỏa nào có hỗ trợ python để biên dịch (như pycharm, visual studio,..). Phải đảm bảo là file code và file test nằm
	chung cùng một thư mục
	-Trên window thì ta có thế như sau:
		- Đảm bảo là python đã được cài đặt (nếu chưa thì có thể tải ở trang python.org)
		- Mở CMD (bằng lệnh Window + R)
		- Chuyển hướng interpreter đến đường đẫn thư mục có chứa file code
		- Gõ lên màn hình : code.py
		- Kết quả sẽ được in ra màn hình