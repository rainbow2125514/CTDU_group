with open("input.txt") as job :
	data1=job.read().replace("m=","").replace("n=","").replace("t=","").replace(","," ").split()
for i in range(len(data1)) :
	data1[i]=int(data1[i])
m=data1[0]
n=data1[1]
data1=data1[2:]
if n != len(data1) :
	with open("output.txt","w") as job :
		job.write("nhap thieu hoac du so luong thoi gian cong viec t")
	exit()
data1.sort(reverse=True)
may=[]
for i in range(m) :
	may.append([])
for i in range(len(data1)) :
	if sum(may[0]) <= sum(may[1]) and sum(may[0]) <= sum(may[2]) :
		may[0].append(data1[i])
	elif sum(may[1]) <= sum(may[0]) and sum(may[1]) <= sum(may[2]) :
		may[1].append(data1[i])
	else :
		may[2].append(data1[i])
with open("output.txt","w") as job :
		job.write("may 1 :")
		job.write(str(may[0]))
		job.write("\nmay 2 :")
		job.write(str(may[1]))
		job.write("\nmay 3 :")
		job.write(str(may[2]))

