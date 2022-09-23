# O segundo desafio foi encontrar o primeiro número primo e palíndromo de 21 dígitps, na expansão de Pi
# Para o segundo desafio foi utilizada uma API q a cada chamada retorna 1000 dígitos da expansão de Pi
# Após ser analisado pouco mais de 1 bilhão de casas o script foi interrompido sem achar o resultado
# Foram adicionado pontos em que eram impressos na tela em que iteração o script se encontrava

import requests
import json
import time
start = time.time()

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


def busca_numero(x):
    p1 = 0
    p2 = 21
    verificador = 0
    while p2 <= 1000:
        numero = int(x[p1:p2])
        
        if ePalindrome(x[p1:p2]) == True:
            if ePrimo(numero) == True:
                verificador = 1
                break
     
        p1 += 1
        p2 += 1
    
    if verificador == 1:
        return numero
    else:
        return False



cont_url = 0
cont_while = 0
iteracao = 0
erros = 0

while cont_while == 0:
    url = "https://api.pi.delivery/v1/pi?start=" + str(cont_url) + "&numberOfDigits=1000&radix=10"
        
    try:
        pi_fetch = requests.get(url)
        pi_dict = pi_fetch.json()
        pi = pi_dict['content']
    
        resposta_numero = busca_numero(pi)
        iteracao +=1
        
        if iteracao % 100 == 0 or iteracao == 1:
            print('url: ',url,'\niteracao número: ',iteracao,'   ', erros, 'erros foram detectados    ','   número:  ', pi, "\n")

        if resposta_numero == False:
            cont_while = 0
            cont_url = cont_url + 980
        else:
            print('número encontrado: ', resposta_numero)
            print('demorou', time.time()-start, 'segundos')
            print("O script realizou", iteracao, "iterações")
            print("erros:", erros)
            cont_while = 1
    except:
        cont_while = 0
        erros += 1