/*
шаг - ~ половина объёма, если нечёт - проверяем 2 разные реализации, +1 и -1

#include <stdio.h>

int[] K={1,2,9,6,0};
int N = 5;


int main(){
	int i, j, h =2, Kj, Ki, h = N/2;;
	//for (s=t-1;s>=0;s--) 
	while (h>1)
	{ 
		for (j=h; j<N; ++j ){
			i=j-h;
			Kj=K[j];
			Ki=K[i];
			while(i>=0){
				if (Kj>=Ki)
					{	
						Kj[i+h]=Kj;
						break;
					}
				K[i+h] = Ki;
				i=i-h;
				}
				K[i+h]=Kj;
			}
		}
		h = h[s]/2;
	}

	cout <<

	return 0;
}






















*/