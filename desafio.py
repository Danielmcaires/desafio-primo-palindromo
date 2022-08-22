
qtd = 200000

def calcula_pi(x):
    k,a,b,a1,b1 = 2,4,1,12,4
    while x > 0:
        p,q,k = k * k, 2 * k + 1, k + 1
        a,b,a1,b1 = a1, b1, p*a + q*a1, p*b + q*b1
        d,d1 = a/b, a1/b1
        while d == d1 and x > 0:
            yield int(d)
            x -= 1
            a,a1 = 10*(a % b), 10*(a1 % b1)
            d,d1 = a/b, a1/b1


def ePrimo(n):
    cont = 0

    for i in range(1, (n + 1)):        
        if n % i == 0:
            cont += 1
        
        if cont > 2:
            break
    
    if cont  == 2 :
        return True
    else:
        return False


def ePalindrome(y):
    if str(y) == str(y)[::-1]:
        return True
    else:
        return False


digitos = ''.join([str(n) for n in list(calcula_pi(qtd))])
p1 = 0
p2 = 9
verificador = 0

while p2 <= qtd:
    numero = int(digitos[p1:p2])
        
    if ePalindrome(digitos[p1:p2]) == True:
        if ePrimo(numero) == True:
            verificador = 1
            break
     
    p1 += 1
    p2 += 1


