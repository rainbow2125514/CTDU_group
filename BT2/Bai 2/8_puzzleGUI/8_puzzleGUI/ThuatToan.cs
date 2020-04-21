using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_puzzleGUI
{
    class ThuatToan
    {
        const int UP = 1;
        const int DN = 2;
        const int LT = 3;
        const int RT = 4;
        const int NO = 0;
        int[,] TAB = new int[3, 3];

        static bool sobang(int[,] S1, int[,] S2)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (S1[i, j] != S2[i, j]) return false;
                }
            return true;
        }// sobang: so sánh TAB S1 và TAB S2

        static void xuat(int[,] S)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write(S[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public class info
        {
            public int[,] S;
            public int g, h, f;
            public int go;
            public int num;
            public int numgo;
            public info() { S = new int[3, 3]; }
        };

        public class List
        {
            public int n;
            public info[] e;
            public List() { n = 0; e = new info[500]; }

            public void them(info X)
            {
                e[n] = new info();
                ganinfo(ref e[n], X);
                n = n + 1;
            }

            public info timfnho()
            {
                int min = e[0].f;
                int vt = 0;
                for (int i = 0; i < n; i++)
                {
                    if (min > e[i].f)
                    {
                        min = e[i].f;
                        vt = i;
                    }
                }
                return e[vt];
            }

            int vitri(info X)
            {
                for (int t = 0; t < n; t++)
                {
                    bool check = true;//kiem tra co
                    for (int i = 0; i < 3; i++)
                        if (check == true)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (X.S[i, j] != e[t].S[i, j])
                                {
                                    check = false;
                                    break;
                                }
                            }
                        }
                    if (check == true) return t;
                }
                return -1;
            }

            void xoa(info X)
            {
                int t = vitri(X);
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        e[t].S[i, j] = e[n - 1].S[i, j];
                    }
                e[t].f = e[n - 1].f;
                e[t].g = e[n - 1].g;
                e[t].go = e[n - 1].go;
                e[t].h = e[n - 1].h;
                e[t].num = e[n - 1].num;
                e[t].numgo = e[n - 1].numgo;
                n = n - 1;
            }


            public void xoainfothua(info T)
            {
                for (int t = 0; t < n; t++)
                {
                    if (sobang(e[t].S, T.S) == true && e[t].go == T.go)
                    {
                        xoa(e[t]);
                        t = t - 1;
                    }
                }
            }//Xóa info chứa TAB trong List giống với S

            public void xuatlist()
            {
                for (int i = 0; i < n; i++)
                {
                    xuat(e[i].S);
                }
            }
        };

        static public List O = new List(), C = new List(), KQ = new List();
        static public int[,] S0 , G ;

        //Hàm chuyển sẽ chuyển [3,3] sang [9]
        static public int[] chuyen1(int[,] a)
        {
            int[] T = new int[9];
            int c = 0;
            for(int i=0;i<3;i++)
                for(int j=0;j<3;j++)
                {
                    T[c] = a[i, j];
                    c = c + 1;
                }
            return T;
        }

        //Hàm chuyển sẽ chuyển [9] sang [3,3]
        static public int[,] chuyen2(int[] a)
        {
            int[,] T = new int[3,3];
            int c = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    T[i,j] = a[c];
                    c = c + 1;
                }
            return T;
        }
        //biến đếm sẽ đánh dấu tất các trường hợp
        static int q = 1;

        static public int count(int[,] S)
        {
            int dem = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (S[i, j] != S0[i, j])
                        dem = dem + 1;
                }
            return dem;
        }//h

        static public void ganbang(int[,] S1, int[,] S2)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    S1[i, j] = S2[i, j];
                }
        }//gán S2 cho S1


        static public void timotrong(int[,] S, ref int k, ref int l)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (S[i, j] == 0)
                    {
                        k = i;
                        l = j;
                    }
                }
        }//tìm vị trí số 0 trong TAB S , k là số hàng , l là số cột


        public static void Xulyke(info X, info BK, ref int go, int k, int l, ref List T)
        {
            BK.num = q;
            q = q + 1;
            BK.numgo = X.num;
            BK.g = X.g + 1;
            int tam = BK.S[k, l];
            if (go == UP)
            {
                BK.S[k, l] = BK.S[k + 1, l];
                BK.S[k + 1, l] = tam;
            }
            else if (go == DN)
            {
                BK.S[k, l] = BK.S[k - 1, l];
                BK.S[k - 1, l] = tam;
            }
            else if (go == LT)
            {
                BK.S[k, l] = BK.S[k, l + 1];
                BK.S[k, l + 1] = tam;
            }
            else
            {
                BK.S[k, l] = BK.S[k, l - 1];
                BK.S[k, l - 1] = tam;
            }
            BK.h = count(G);
            BK.f = BK.g + BK.h;
            T.them(BK);
        }//thêm các giá trị trong info BK và lưu vào List T


        public static void timgo(List T, info S, ref List M)
        {
            for (int t = 0; t < T.n; t++)
            {
                if (S.numgo == T.e[t].num)
                {
                    M.them(T.e[t]);
                    return;
                }
            }
            return;
        }//Tìm trường hợp tiếp theo trong List T dựa vào numgo và lưu vào List M

        public static void ganinfo(ref info T, info A)
        {
            ganbang(T.S, A.S);
            T.f = A.f;
            T.g = A.g;
            T.go = A.go;
            T.h = A.h;
            T.num = A.num;
            T.numgo = A.numgo;
        }//gan info A vao info T
        static public void Astart()
        {
            info X = new info() { };
            ganbang(X.S, G);
            X.g = 0;
            X.h = count(G);
            X.f = X.h;
            X.go = NO;
            X.num = q;
            q = q + 1;
            X.numgo = -1;
            O.them(X);
            while (O.n > 0)
            {
                info N = new info();
                int k = 0;
                int l = 0;
                N = O.timfnho();
                ganinfo(ref X, N);
                O.xoainfothua(X);
                C.them(X);
                if (sobang(X.S, S0))
                {
                    KQ.them(X);
                    KQ.n = 1;
                    return;
                }
                timotrong(X.S, ref k, ref l);

                //k>0 nên có thê Up được
                if (k > 0 && X.go != UP)
                {
                    info BK = new info();
                    ganbang(BK.S, X.S);
                    BK.go = DN;
                    Xulyke(X, BK, ref BK.go, k, l, ref O);
                }

                //k<2 nên có thê Down được
                if (k < 2 && X.go != DN)
                {
                    info BK = new info();
                    ganbang(BK.S, X.S);
                    BK.go = UP;
                    Xulyke(X, BK, ref BK.go, k, l, ref O);
                }

                //l>0 nên có thể Left được
                if (l > 0 && X.go != LT)
                {
                    info BK = new info();
                    ganbang(BK.S, X.S);
                    BK.go = RT;
                    Xulyke(X, BK, ref BK.go, k, l, ref O);
                }

                //l<2 nên có thể Right được
                if (l < 2 && X.go != RT)
                {
                    info BK = new info();
                    ganbang(BK.S, X.S);
                    BK.go = LT;
                    Xulyke(X, BK, ref BK.go, k, l, ref O);
                }
            }
            return;
        }

        public static void timkq()
        {
            int t = KQ.n;
            while (KQ.e[t - 1].numgo != -1)
            {
                timgo(C, KQ.e[t - 1], ref KQ);
                t = t + 1;
            }
        }

        //Hàm này sẽ lấy dữ liệu từ a truyền sang b

        static public void xuly()
        {
            Astart();
            timkq();
        }
    }
}
