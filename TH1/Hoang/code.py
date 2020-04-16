from operator import itemgetter, attrgetter

class may:
    def __init__(self, time, cv, idmay):
        self.SoGioLam = time
        self.DsCongvc = cv
        self.idmay = idmay
    def ThemViecLam(self, time, idcv):
        self.SoGioLam += time
        self.DsCongvc.append(idcv)
    def ThoiGianLamVc(self):
        return self.SoGioLam
    def CongViecDalam(self):
        return self.DsCongvc
    def IDMAY(self):
        return self.idmay
    def __getitem__(self,key):
        print ("Inside `__getitem__` method!")
        return getattr(self,key)
    def __repr__(self):
        return repr(tuple([self.SoGioLam, self.DsCongvc, self.idmay]))

    
def sortdsmay(dsmay):
    
    for idmay in range(1, len(dsmay)):
        may = dsmay[idmay]
        keymay = dsmay[idmay].ThoiGianLamVc()
        j = idmay - 1
        while ((dsmay[j].ThoiGianLamVc() > keymay) and (j >= 0)):
            dsmay[j + 1] = dsmay[j]
            j = j - 1
        dsmay[j + 1] = may
def sortdsmay2(dsmay):
    
    for idmay in range(1, len(dsmay)):
        may = dsmay[idmay]
        keymay = dsmay[idmay].IDMAY()
        j = idmay - 1
        while ((dsmay[j].IDMAY() > keymay) and (j >= 0)):
            dsmay[j + 1] = dsmay[j]
            j = j - 1
        dsmay[j + 1] = may
# main

tij = []

#doc du lieu
with open("test.txt", "r") as filein:
    n, m = [int(x) for x in filein.readline().split()]
    for i in range(m):
        tij.append([int(x) for x in filein.readline().split()])

dsmay = []
dscvdalam = []

# danh ma may
for i in range(m):
    dsmay.append(may(0, [], i))
    
# phan cong
while len(dscvdalam) < n:
    sortdsmay(dsmay)

    idmay = dsmay[0].IDMAY()

    time = min(tij[idmay])
    idcv = tij[idmay].index(time)
    chot = max(tij[idmay])
    
    if idcv in dscvdalam:
        tam = tij[idmay].copy()

        while idcv in dscvdalam:  
            if time in tam:
                tam[idcv] += chot
            
            time = min(tam)
            idcv = tam.index(time)
            
    dsmay[0].ThemViecLam(time, idcv)
    dscvdalam.append(idcv)

sortdsmay2(dsmay)
for may in dsmay:
    print(f"May {may.IDMAY()}:" )
    print(f"\tTong thoi gian : {may.ThoiGianLamVc()}")
    print(f"\tCong viec : {may.CongViecDalam()}")
