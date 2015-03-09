#projecteuler.net
#http://labs.codecademy.com/

def mainE1(upper):
    threesAndFives = [i for i in range(upper) if i % 3 == 0 or i % 5 == 0]
    return sum(threesAndFives)
print mainE1(1000)

def mainE2(upper):
    fibo = [1, 2]
    while (fibo[-1] + fibo[-2]) < upper:
        fibo.append(fibo[-1] + fibo[-2])
    fiboEven = [i for i in fibo if i%2 == 0]
    return sum(fiboEven)
print mainE2(4000000)

def mainE3(number):
    precedingNumbers = range(2, int(number**(0.5))+1)
    factors = [j for j in precedingNumbers if number % j == 0]
    primeFactors = [k for k in factors if isPrimeE3(k)]
    return max(primeFactors)
def isPrimeE3(number):
    candidateFactors = range(2, int(number**(0.5))+1)
    factors = [i for i in candidateFactors if number % i == 0]
    return len(factors) == 0
print mainE3(600851475143) 

def mainE4(upper):
    largePalindrome = []
    for i in range(upper**0.5, upper)[::-1]:
        for j in range(upper**0.5, upper)[::-1]:
            if isPalindromeE4(i*j):
                largePalindrome.append(i*j)
                break
    #print largePalindrome
    return max(largePalindrome)
def isPalindromeE4(value):
    valStr = str(value)
    retValue = True
    for i in range(0, len(valStr)/2):
        retValue = retValue and valStr[i] == valStr[-1+i*-1]
    return retValue
print mainE4(1000)

def mainE5Brute(upper):
    number = int(upper)
    while (upper-1) > len([i for i in range(2, upper+1) if number % i == 0]):
        number+= 1
    return number
print mainE5Brute(10)

def mainE5(upper):
    factors = [1,2]
    for i in range(3, upper+1):
        if prodE5(factors) % i != 0:
            if isPrimeE5(i):
                # Add primes to ecuation
                factors.append(i)
            else:
                for j in factors[::-1]:
                    if prodE5(factors)*j % i == 0:
                        # Add multiple instances of primes to complete numbers (eg 8)
                        factors.append(j)
                        break
            print factors
    return prodE5(factors)
def prodE5(numbers):
    ret = 1
    for i in numbers:
        ret *= i
    return ret
def isPrimeE5(number):
    candidateFactors = range(2, int(number**(0.5))+1)
    factors = [i for i in candidateFactors if number % i == 0]
    return len(factors) == 0
print mainE5(20)

def mainE6(upper):
    squareSums = sum(range(1, upper+1))**2
    sumSquares = sum([i**2 for i in range(1, upper+1)])
    return squareSums - sumSquares
print mainE6(100)

def mainBruteE7(nth):
    currentNumber = 4
    primesFound = [2,3]
    while len(primesFound) < nth:
        if len([i for i in primesFound if i <= currentNumber**0.5 and currentNumber % i == 0]) == 0:
            primesFound.append(int(currentNumber))
        currentNumber += 1
    return primesFound[-1]
print mainBruteE7(300)

def mainEratosthenesE7(nth):
    upper = nth*12
    numbers = [True]*(upper+1)
    numbers[0]=False
    numbers[1]=False
    found = 1
    p = 3
    while found < nth and p < upper:
        if numbers[p]:
            found += 1
            f = int(p)
            n = f*p
            while n <= upper:
                numbers[n] = False
                f += 1
                n = f*p
        p += 2
    return p-2
print mainEratosthenesE7(10001)
# 104743

def mainE8(charLength, inputString):
    numberCollection = []
    for start in range(0, len(inputString)-charLength):
        numberCollection.append(list(inputString[start:start+charLength]))
    max = 0
    maxList = ''
    for numbers in numberCollection:
        current = 1
        for num in numbers:
            current *= int(num)
        if current > max:
            max = int(current)
            maxList = numbers
    print maxList
    return max
print mainE8(13, "731671765313306249192251196744265747423"
    + "55349194934969835203127745063262395783180169848018"
    + "6947885184385861560789112949495459501737958331952"
    + "8532088055111254069874715852386305071569329096329"
    + "5227443043557668966489504452445231617318564030987"
    + "1112172238311362229893423380308135336276614282806"
    + "4444866452387493035890729629049156044077239071381"
    + "0515859307960866701724271218839987979087922749219"
    + "0169972088809377665727333001053367881220235421809"
    + "7512545405947522435258490771167055601360483958644"
    + "6706324415722155397536978179778461740649551492908"
    + "6256932197846862248283972241375657056057490261407"
    + "9729686524145351004748216637048440319989000889524"
    + "3450658541227588666881164271714799244429282308634"
    + "6567481391912316282458617866458359124566529476545"
    + "6828489128831426076900422421902267105562632111110"
    + "9370544217506941658960408071984038509624554443629"
    + "8123098787992724428490918884580156166097919133875"
    + "4992005240636899125607176060588611646710940507754"
    + "1002256983155200055935729725716362695618826704282"
    + "52483600823257530420752963450")

def mainE9(value):
    for a in range(1, value+1):
        for b in range(a+1, value+1):
            c = (int(a)**2 + int(b)**2)**0.5
            if c == int(c):
                c = int(c)
                #print a, b, c
                if (a+b+c) == value:
                    return [a, b, c, a*b*c]
    return []
print mainE9(1000)

def mainBruteE10(upper):
    primes = [2,3]
    current = 5
    while current < upper:
        for p in primes:
            if p > current**0.5:
                primes.append(current)
                break
            if current % p == 0:
                break
        current += 1
    return sum(primes)
print mainBruteE10(2000)

def mainEratosthenesE10(upper):
    numbers = [True]*(upper+1)
    numbers[0]=False
    numbers[1]=False
    sum = 2
    p = 3
    while p < upper:
        if numbers[p]:
            sum += p
            f = int(p)
            n = f*p
            while n <= upper:
                numbers[n] = False
                f += 1
                n = f*p
        p += 2
    return sum
print mainEratosthenesE10(2000000)
# 142913828922

matrix = [
[8,2,22,97,38,15,0,40,0,75,4,5,7,78,52,12,50,77,91,8],
[49,49,99,40,17,81,18,57,60,87,17,40,98,43,69,48,4,56,62,0],
[81,49,31,73,55,79,14,29,93,71,40,67,53,88,30,3,49,13,36,65],
[52,70,95,23,4,60,11,42,69,24,68,56,1,32,56,71,37,2,36,91],
[22,31,16,71,51,67,63,89,41,92,36,54,22,40,40,28,66,33,13,80],
[24,47,32,60,99,3,45,2,44,75,33,53,78,36,84,20,35,17,12,50],
[32,98,81,28,64,23,67,10,26,38,40,67,59,54,70,66,18,38,64,70],
[67,26,20,68,2,62,12,20,95,63,94,39,63,8,40,91,66,49,94,21],
[24,55,58,5,66,73,99,26,97,17,78,78,96,83,14,88,34,89,63,72],
[21,36,23,9,75,0,76,44,20,45,35,14,0,61,33,97,34,31,33,95],
[78,17,53,28,22,75,31,67,15,94,3,80,4,62,16,14,9,53,56,92],
[16,39,5,42,96,35,31,47,55,58,88,24,0,17,54,24,36,29,85,57],
[86,56,0,48,35,71,89,7,5,44,44,37,44,60,21,58,51,54,17,58],
[19,80,81,68,5,94,47,69,28,73,92,13,86,52,17,77,4,89,55,40],
[4,52,8,83,97,35,99,16,7,97,57,32,16,26,26,79,33,27,98,66],
[88,36,68,87,57,62,20,72,3,46,33,67,46,55,12,32,63,93,53,69],
[4,42,16,73,38,25,39,11,24,94,72,18,8,46,29,32,40,62,76,36],
[20,69,36,41,72,30,23,88,34,62,99,69,82,67,59,85,74,4,36,16],
[20,73,35,29,78,31,90,1,74,31,49,71,48,86,81,16,23,57,5,54],
[1,70,54,71,83,51,54,69,16,92,33,48,61,43,52,1,89,19,67,48]
]
def mainE11():
    maxProd = 0
    factors = []
    # Vertical
    for i in range(0, len(matrix)):
        for j in range(0, len(matrix[i])):
            if j+3 < len(matrix[i]):
                prodH = matrix[i][j] * matrix[i][j+1] * matrix[i][j+2] * matrix[i][j+3]
                if prodH > maxProd:
                    maxProd = int(prodH)
                    factors = [matrix[i][j], matrix[i][j+1], matrix[i][j+2], matrix[i][j+3]]
            if i+3 < len(matrix):
                prodV = matrix[i][j] * matrix[i+1][j] * matrix[i+2][j] * matrix[i+3][j]
                if prodV > maxProd:
                    maxProd = int(prodV)
                    factors = [matrix[i][j], matrix[i+1][j], matrix[i+2][j], matrix[i+3][j]]
            if i+3 < len(matrix) and j+3 < len(matrix[i]):
                prodD = matrix[i][j] * matrix[i+1][j+1] * matrix[i+2][j+2] * matrix[i+3][j+3]
                if prodD > maxProd:
                    maxProd = int(prodD)
                    factors = [matrix[i][j], matrix[i+1][j+1], matrix[i+2][j+2], matrix[i+3][j+3]]
            if i >= 3 and j+3 < len(matrix[i]):
                prodE = matrix[i][j] * matrix[i-1][j+1] * matrix[i-2][j+2] * matrix[i-3][j+3]
                if prodE > maxProd:
                    maxProd = int(prodE)
                    factors = [matrix[i][j], matrix[i-1][j+1], matrix[i-2][j+2], matrix[i-3][j+3]]
    print factors
    return maxProd
print mainE11()
# [87, 97, 94, 89]
# 70600674

# def main_euler_12(target_factors):
    # triangle_index = 1
    # triangle = 1
    # current_factors = 0
    # while current_factors <= target_factors:
        # triangle_index += 1
        # triangle += triangle_index
        # current_factors= 1 # Includes Self
        # for i in range(1, (triangle/2)+1):
            # if triangle % i == 0:
                # current_factors += 1
    # return triangle
# print main_euler_12(50)

def euler_12_sq(target):
    current_factors = 2
    current_number = 3
    triang = 3
    index = 2
    fact_root = int(euler_12_fact(int(target**0.5)))
    while current_factors <= target:
        index += 1
        triang += int(index)
        # Skip calculating the factors of lesser numbers.
        if triang > fact_root:
            this_factors = 2 # Includes Self and Unit
            n = 2
            while n < (triang**0.5):
                # Include 2 factors per successful find, before the perfect square
                if triang % n == 0:
                    this_factors += 2
                n += 1
            if triang**0.5 == int(triang**0.5):
                # Include 1 factor if it is perfect square
                this_factors += 1
            if this_factors > current_factors:
                current_factors = int(this_factors)
                current_number = int(triang)
    return current_number
def euler_12_fact(number):
    res = 2
    n = 3
    while n <= number:
        res *= n
        n += 1
    return res
print(euler_12_sq(50))
#print(euler_12_sq(500))

def euler_yield_12(max_factors):
    tri = 1
    i = 1
    factors = 1
    fact_root = int(factorial_12(int(max_factors**0.5)))
    while 1:
        if tri > fact_root:
            if sum(factors_12(tri)) >= max_factors:
                break
        i += 1
        tri += i
    return tri
def factors_12(num):
    x = 1
    numsqrt = num**0.5
    while x < numsqrt:
        if num % x == 0:
            yield 1
        x += 1 
    yield 2
def factorial_12(number):
    res = 2
    n = 3
    while n <= number:
        res *= n
        n += 1
    return res
print(euler_yield_12(5))

def mainE13():
    sum = 0
    sum += 37107287533902102798797998220837590246510135740250
    sum += 46376937677490009712648124896970078050417018260538
    #....
    print sum
mainE13() 
#5537376230390876637302048746832985971773659831892672

def mainE14(upper):
    #Collatz sequence
    num = 2
    collatz = [2, 1]
    i = 3
    while i < upper:
        new_collatz = []
        collatz_number = int(num)
        while collatz_number != 1:
            new_collatz.append(collatz_number)
            if collatz_number%2 == 0:
                collatz_number = collatz_number / 2
            else:
                collatz_number = (collatz_number * 3) + 1
        new_collatz.append(collatz_number)
        if len(new_collatz) > len(collatz):
            collatz = new_collatz
            num = i
        i += 1
    print collatz
    return num
print mainE14(1000)
#print mainE(1000000)
#837799

def mainE15(gridsize):
    i = 1
    fact_x = 1
    fact_2x = 1
    while i <= gridsize:
        fact_x *= i
        fact_2x *= i
        i += 1
    while i <= gridsize*2:
        fact_2x *= i
        i += 1
    return fact_2x / fact_x**2
print mainE15(2)
print mainE15(20)
# 137846528820
    

def mainE17(upper):
    numbers = [numToStrE17(i).strip() for i in range(1, upper+1)]
    #print numbers
    return sum([len(item.replace(" ", "")) for item in numbers])
def numToStrE17(num):
    result = ""
    textUnits = ["", " one", " two", " three", " four"
                , " five", " six", " seven", " eight"
                , " nine"]
    textDecens = ["", " ten", " twenty", " thirty", " forty"
                , " fifty", " sixty", " seventy"
                , " eighty", " ninety"]
    for n in range(0, 4):
        digit = num/(10**n) % 10
        digitStr = ""
        if digit > 0:

            if n == 0:

                digitStr = textUnits[digit]

            elif n == 1:
                digitStr = textDecens[digit]
            elif n == 2:
                digitStr = textUnits[digit] + " hundred
                if result != "":
                    digitStr = digitStr + " and"
            elif n == 3:
                digitStr = textUnits[digit] + " thousand"
            result = digitStr + result
    specialCases = [ ["ten one", "eleven"], ["ten two", "twelve"]
        , ["ten three", "thirteen"], ["ten four", "fourteen"]
        , ["ten five", "fifteen"], ["ten six", "sixteen"]
        , ["ten seven", "seventeen"], ["ten eight", "eighteen"]
        , ["ten nine", "nineteen"]  ]
    for sCase in specialCases:
        result = result.replace(sCase[0], sCase[1])
    return result
print mainE17(1000)

matrix_18 = [
[75], 
[95, 64], 
[17, 47, 82], 
[18, 35, 87, 10], 
[20, 4, 82, 47, 65], 
[19, 1, 23, 75, 3, 34], 
[88, 2, 77, 73, 7, 63, 67], 
[99, 65, 4, 28, 06, 16, 70, 92], 
[41, 41, 26, 56, 83, 40, 80, 70, 33], 
[41, 48, 72, 33, 47, 32, 37, 16, 94, 29], 
[53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14], 
[70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57], 
[91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48], 
[63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31], 
[4, 62, 98, 27, 23, 9, 70, 98, 73, 93, 38, 53, 60, 4, 23] ]
def euler_18(i, j):
    if i >= len(matrix_18):
        return 0
    else:
        x = matrix_18[i][j]
        y = euler_18(i+1, j)
        z = euler_18(i+1, j+1)
        if y > z:
            return x + y
        else:
            return x + z
print euler_18(0, 0)

def mainE19(min, max):
    countSunday = 0
    if min == 1900:
        dayOfTheWeek = 1
    elif min == 1901:
        dayOfTheWeek = 2
    months = [31,28,31,30,31,30,31,31,30,31,30,31]
    year = []
    leapyear = []
    for m in months:
        for i in range(1, m+1):
            year.append(i)
            leapyear.append(i)
        if m==28:
            leapyear.append(29)
    for y in range(min, max+1):
        if (y%4 == 0 and y%100!=0) or (y%100==0 and y%400==0):
            #leap
            month = 0
            for dayInYear in range(0, len(leapyear)):
                if leapyear[dayInYear] == 1:
                    month += 1
                if dayOfTheWeek == 7 :
                    #Is Sunday
                    if leapyear[dayInYear] == 1:
                        countSunday += 1
                        print str(dayInYear) + ", " + str(month) + "/1/" + str(y)
                    dayOfTheWeek = 1
                else:
                    dayOfTheWeek += 1
        else:
            #regular
            month = 0
            for dayInYear in range(0, len(year)):
                if year[dayInYear] == 1:
                    month += 1
                if dayOfTheWeek == 7 :
                    #Is Sunday
                    if year[dayInYear] == 1:
                        countSunday += 1
                        print str(dayInYear) + ", " + str(month) + "/1/" + str(y)
                    dayOfTheWeek = 1
                else:
                    dayOfTheWeek += 1
    return countSunday
print mainE19(1901, 2000)

def mainE20(upper):
    prod = 1
    for i in range(2, upper+1):
        prod *= i
    return sum([int(i) for i in str(prod)])
print mainE20(100)   

def euler_21(upper):
    amicable = [True]*(upper+1)
    amicable[0] = False
    amicable_number = []
    ix = 1
    while ix <= upper:
        if amicable[ix]:
            sum_divs = sum_divisors(ix)
            if sum_divs != ix:
                if sum_divisors(sum_divs) == ix:
                    amicable_number.append(ix)
                    if sum_divs <= upper:
                        amicable_number.append(sum_divs)
            amicable[ix] = False
            if sum_divs <= upper:
                amicable[sum_divs] = False
        ix += 1
    print(amicable_number)
    return sum(amicable_number)
def sum_divisors(num):
    i = 2
    sum = 1
    while i < num//2:
        if num % i == 0:
            sum += i
        i += 1
    return sum
print(euler_21(2900))
#[220, 284, 1184, 1210, 2620, 2924, 5020, 5564, 6232, 6368]
#31626

def mainE25(digits):    
    a = 1
    b = 1
    count = 2
    while len(str(b)) < digits:
        t = a+b
        a = b
        b = t
        count += 1
    return count
print mainE25(1000)

def euler_28(size):
    matrix28 = [[0 for i in range (size)] for j in range(size)]
    i = len(matrix28)//2
    j = int(i)
    lenmx = len(matrix28)
    sumX = 0
    current = 1
    direction = "right"
    matrix28[i][j] = int(current)
    sumX += current
    while current < (lenmx**2):
        if direction == "right":
            if i+1 < lenmx:
                i += 1
                current += 1
                matrix28[i][j] = int(current)
            if j+1 < lenmx:
                if matrix28[i][j+1] == 0:
                    direction = "down"
        elif direction == "down":
            if j+1 < lenmx:
                j += 1
                current += 1
                matrix28[i][j] = int(current)
            if i-1 >= 0:
                if matrix28[i-1][j] == 0:
                    direction = "left"
        elif direction == "left":
            if i-1 >= 0:
                i -= 1
                current += 1
                matrix28[i][j] = int(current)
            if j-1 >= 0:
                if matrix28[i][j-1] == 0:
                    direction = "up"
        elif direction == "up":
            if j-1 >= 0:
                j -= 1
                current += 1
                matrix28[i][j] = int(current)
            if i+1 < lenmx:
                if matrix28[i+1][j] == 0:
                    direction = "right"
        if i == j:
            sumX += current
        elif (lenmx - j - 1) == i:
            sumX += current
    return sumX
    #print matrix28
    #sumA = sum(matrix28[i][i] for i in range(0, lenmx))
    #sumB = sum(matrix28[lenmx-1-i][i] for i in range(0, lenmx))
    #return (sumA + sumB - 1)
print(euler_28(1001))
# 669171001

def euler_29(a, b):
    res = []
    for i in xrange(2, a+1):
        for j in xrange(2, b+1):
            num = i**j
            if num not in res:
                res.append(num)
    print(res)
    return len(res)
print(euler_29(100, 100))
#9183

def main30(upper):
    fifths = []
    for num in range(2, upper):
        digits = [int(i) for i in str(num)]
        prod = 0
        for dig in digits:
            prod += dig**5
        if prod == num:
            fifths.append(num)
    print fifths
    return sum(fifths)
print mainE30(20000)

def mainE31(amount):
    cases = 0
    #options = []
    #current = c1 + 2*c2 + 5*c5 + 10*c10 + 20*c20 + 50*c50 + 100*c100 + 200*c200
    for c200 in range(0, amount/200+1):
        current = 200*c200
        if current == amount:
            cases += 1
            #options.append([c200])
            break
        for c100 in range(0, (amount - c200*200)/100 + 1):
            current = 100*c100 + 200*c200
            if current == amount:
                cases += 1
                #options.append([c200, c100])
                break
            for c50 in range(0, (amount - c200*200 - c100*100)/50 + 1):
                current = 50*c50 + 100*c100 + 200*c200
                if current == amount:
                    cases += 1
                    #options.append([c200, c100, c50])
                    break
                for c20 in range(0, (amount - c200*200 - c100*100 - c50*50)/20 + 1):
                    current = 20*c20 + 50*c50 + 100*c100 + 200*c200
                    if current == amount:
                        cases += 1
                        #options.append([c200, c100, c50, c20])
                        break
                    for c10 in range(0, (amount - c200*200 - c100*100 - c50*50 - c20*20)/10 + 1):
                        current = 10*c10 + 20*c20 + 50*c50 + 100*c100 + 200*c200
                        if current == amount:
                            cases += 1
                            #options.append([c200, c100, c50, c20, c10])
                            break
                        for c5 in range(0, (amount - c200*200 - c100*100 - c50*50 - c20*20 - c10*10)/5 + 1):
                            current = 5*c5 + 10*c10 + 20*c20 + 50*c50 + 100*c100 + 200*c200
                            if current == amount:
                                cases += 1
                                #options.append([c200, c100, c50, c20, c10, c5])
                                break
                            for c2 in range(0, (amount - c200*200 - c100*100 - c50*50 - c20*20 - c10*10 - c5*5)/2 + 1):
                                current = 2*c2 + 5*c5 + 10*c10 + 20*c20 + 50*c50 + 100*c100 + 200*c200
                                if current == amount:
                                    cases += 1
                                    #options.append([c200, c100, c50, c20, c10, c5, c2])
                                    break
                                for c1 in range(0, (amount - c200*200 - c100*100 - c50*50 - c20*20 - c10*10 - c5*5 - c2*2) + 1):
                                    current = c1 + 2*c2 + 5*c5 + 10*c10 + 20*c20 + 50*c50 + 100*c100 + 200*c200
                                    if current == amount:
                                        cases += 1
                                        #options.append([c200, c100, c50, c20, c10, c5, c2, c1])
                                        break
    #print options
    return cases
print mainE31(200)


def mainE34(upper):
    # Number is Sum of DigitFactorials
    fact = [0, 1, 2]
    for i in range(3, 10):
        fact.append(fact[i-1]*i)
    res = 0
    resList = []
    for number in range(3, upper+1):
        sum = 0
        for digit in str(number):
            sum += fact[int(digit)]
        if sum == number:
            resList.append(number)
            res += number
    print resList
    return res
print mainE34(2000)
print mainE34(1000000)

def euler_34():
    factorials = [0, 1]
    for i in range(2, 10):
        factorials.append(factorials[i-1] * i)
    upper = 2540162 # 2540161
    number = 3
    while number < upper:
        sumF = 0
        i = int(number)
        while i > 0:
            sumF += factorials[int(i%10)]
            if sumF > number:
                break
            i %= 10
        if sumF == number:
            yield number
        number += 1
print(sum(euler_34()))

def euler_list_34():
    factorials = [0, 1]
    for i in range(2, 10):
        factorials.append(factorials[i-1] * i)
    upper = 2540162
    return sum([num for num in range(3, upper+1) if num == sum([factorial[int(i)] for i in str(num)])])

def rotations_35(number):
    strnum = str(number)
    res = []
    curr_str = strnum[1:] + strnum[0]
    ix = 0
    while ix < len(strnum):
        if len(str(int(curr_str))) == len(strnum):
            res.append(int(curr_str))
        else:
            return []
        curr_str = str(curr_str)[1:] + str(curr_str)[0]
        ix += 1
    return res        
def euler_35_erathostenes(upper):
    # Find Primes through Sieve
    #numbers = [True]*(upper+1)
    numbers = [i % 2 == 1 for i in range(upper+1)] # Only odd numbers are Primes
    numbers[0]=False
    numbers[1]=False
    numbers[2]=True # Excepting 2
    p = 3
    while p <= upper:
        if numbers[p]:
            f = int(p)
            n = f*p
            while n <= upper:
                numbers[n] = False
                f += 1
                n = f*p
        p += 2
    #circular = [2]
    i = 3
    count = 1
    while i <= upper:
        if numbers[i]:
            str_i = str(i)
            if len(str_i) == 1:
                #circular.append(i)
                count += 1
            elif len(str_i) > 1:
                rotations = rotations_35(str(i))
                if len(rotations) > 0:
                    is_circular = True
                    for rotI in rotations:
                        is_circular = is_circular and (numbers[rotI]) #and (rotI % 2 == 1)
                        if not is_circular:
                            break
                    if is_circular:
                        #circular.append(i)
                        count += 1
        i += 2
    #print(circular)
    return count
#print(euler_35_erathostenes(1000000))
#Sum: 8184200
#Count: 55


def mainE36(upper):
    #Double Palindromes
    #palindStr = []
    number = 0
    res = 0
    while number < upper:
        if str(number) == str(str(number)[::-1]):
            if str(bin(number)[2:]) == str(bin(number)[2:][::-1]):
                #palindStr.append(str(number) + "(" + bin(number)[2:] + ")")
                res += number
        number += 1
    #print palind
    return res
print mainE36(1000000)
#872187

def substrings_37(input_string):
    length = len(input_string)
    return [input_string[0:i+1] for i in range(0, length-1)] + [input_string[j:length] for j in range(1, length)]
def euler_37_erathostenes(upper):
    numbers = [True]*(upper+1)
    numbers[0]=False
    numbers[1]=False
    found = 1
    p = 2
    truncatable = [] # [23, 37, 53, 73, 313, 317, 373, 797, 3137, 3797, 739397]
    while p < upper and len(truncatable) < 11:
        if numbers[p]:
            found += 1
            #
            if len(str(p)) >= 2: # and p > 739397 and p > 5000000:
                is_trunc = True            
                for subP in substrings_37(str(p)):
                    is_trunc = is_trunc and (numbers[int(subP)])
                    if not is_trunc:
                        break
                if is_trunc:
                    truncatable.append(p)
            #
            f = int(p)
            n = f*p
            while n <= upper:
                numbers[n] = False
                f += 1
                n = f*p
        p += 1
    print truncatable
    return sum(truncatable)
print euler_37_erathostenes(1000000)
# (1200000, [37, 53, 73, 313, 317, 373, 797, 3137, 3797, 739397])
# 23 works too --> [23, 37, 53, 73, 313, 317, 373, 797, 3137, 3797, 739397]
# 748317

def getPermutations(a):
   if len(a)==1:
      yield a
   else:
      for i in range(len(a)):
         this = a[i]
         rest = a[:i] + a[i+1:]
         for p in getPermutations(rest):
            yield [this] + p

def permuts_43():
    permutations = []
    r1 = range(10)
    for i1 in r1:
        r2 = range(10)
        r2.remove(i1)
        for i2 in r2:
            r3 = r2[:]
            r3.remove(i2)
            for i3 in r3:
                r4 = r3[:]
                r4.remove(i3)
                for i4 in r4:
                    r5 = r4[:]
                    r5.remove(i4)
                    for i5 in r5:
                        r6 = r5[:]
                        r6.remove(i5)
                        for i6 in r6:
                            r7 = r6[:]
                            r7.remove(i6)
                            for i7 in r7:
                                r8 = r7[:]
                                r8.remove(i7)
                                for i8 in r8:
                                    r9 = r8[:]
                                    r9.remove(i8)
                                    for i9 in r9:
                                        r10 = r9[:]
                                        r10.remove(i9)
                                        for i10 in r10:
                                            perm = str(i1)+str(i2)+str(i3)+str(i4)+str(i5) + \
                                                            str(i6)+str(i7)+str(i8)+str(i9)+str(i10)
                                        permutations.append(perm)
    return permutations
def d_43(num, a, b, c):
    return int(num[a-1] + num[b-1] + num[c-1])
def euler_43():
    perm_list = permuts_43()
    length = len(perm_list)
    i = 0
    res = 0
    res_list = []
    while i < length:
        p = str(perm_list[i])
        if d_43(p, 2,3,4) % 2 == 0:
            if d_43(p, 3, 4, 5) % 3 == 0:
                if d_43(p, 4, 5, 6) % 5 == 0:
                    if d_43(p, 5, 6, 7) % 7 == 0:
                        if d_43(p, 6, 7, 8) % 11 == 0:
                            if d_43(p, 7, 8, 9) % 13 == 0:
                                if d_43(p, 8, 9, 10) % 17 == 0:
                                    res += perm_list[i]
                                    res_list.append(perm_list[i])
        i += 1
    print(res_list)
    return res
print(euler_43())

def euler_44(upper):
    pentas = [(n*(3*n-1))/2 for n in range(1, upper+1)]
    pentas_sums = []
    pentas_diff = int(pentas[-1])
    pentas_res = []
    for i in range(upper):
        for j in range(i+1, upper):
            if (pentas[i]+pentas[j]) > pentas[-1]:
                break
            if ((pentas[i]+pentas[j]) in pentas) and ((pentas[j]-pentas[i]) in pentas):
                pentas_sums.append([pentas[i], pentas[j]])
                if (pentas[j]-pentas[i]) < pentas_diff:
                    pentas_diff = (pentas[j]-pentas[i])
                    pentas_res = [pentas[i], pentas[j]]
    print(pentas_sums)
    print(pentas_res)
    return pentas_diff
    
print(euler_44(2500))
#[1560090, 7042750]
#5482660

def tri_45(n):
    return (n*(n+1))/2
def penta_45(n):
    return (n*(3*n-1))/2
def hexa_45(n):
    return (n*(2*n-1))
def euler_45(upper):
    t = 286 #285
    p = 166 #165
    h = 144 #143
    ix = 0
    tri = tri_45(t)
    penta = penta_45(p)
    hexa = hexa_45(h)
    while (tri != penta or penta != hexa or hexa != tri) and ix < upper:
        if (tri < penta and tri < hexa) or (penta == hexa and tri < penta) or (tri == penta and hexa > tri):
            t += 1
            tri = tri_45(t)
        elif (penta < tri and penta < hexa) or (hexa == tri and penta < hexa) or (penta == hexa and tri > penta):
            p += 1
            penta = penta_45(p)
        elif (hexa < tri and hexa < penta) or (tri == penta and hexa < tri) or (hexa == tri and penta > hexa):
            h += 1
            hexa = hexa_45(h)
        ix += 1
    return [tri, t, penta, p, hexa, h]
print(euler_45(1000000))
# 1533776805 ["T(55385)", "P(31977)", "H(27693)"]

def euler_48(upper):
    return str(sum([i**i for i in range(1, upper+1)]))[-10:]
print euler_48(1000)

def euler_67():
    # Bottom-up
    i = len(matrix_67)-2
    while i >= 0:
        j = 0
        while j < len(matrix_67[i]):
            matrix_67[i][j] += max(matrix_67[i+1][j], matrix_67[i+1][j+1])
            j+= 1
        i -= 1
    return matrix_67[0][0]
print(euler_67())

def euler_76():
    total_amount=100 #200
    values= range(1,100) #[1,2,5,10,20,50,100,200]

    n_ways=[[0 for i in range(len(values))] for j in range(total_amount+1)]
    #total_amount+1:will use index 0 for the case of no rest
    #n_ways[N,M] = number of ways to make N p with coins worth M p or less

    for amount in range(total_amount+1):
        #there is only 1 way to to make each amount with only 1 p coins so:
        n_ways[amount][0]=1

        for highest_possible_coin in values[1:]:
            for n_possible_highest_coin in range(amount/highest_possible_coin+1):
                n_ways[amount][values.index(highest_possible_coin)] \
                += n_ways[amount-highest_possible_coin*n_possible_highest_coin]\
                         [values.index(highest_possible_coin)-1]
        print "There are %d ways to make %d p with %dp or smaller/no coins"\
              %(n_ways[amount][values.index(highest_possible_coin)],
              amount,
              highest_possible_coin)
euler_76()

# # # # # #####################
def make77(num, largest): #Largest initially called as num
    if num == 0:
        return 1
    if num < 0:
        return 0
    total = 0
    for unit in prime_list77:
        if unit <= largest:
            total += make77(num - unit, unit)
    return total

tot77 = 0
upp = 10
prime_list77 = prime_list(500)
while(tot77<5000):
    upp += 1
    tot77 = make77(upp, upp)
print(upp)
# # # # # #####################

def euler_92(lower,upper):
    count = 0
    for x in range(lower, upper):
        #print(x, digit_squares_92(x))
        if digit_squares_92(x) == 89:
            count += 1
    return count
def digit_squares_92(num):
    res = int(num)
    #steps = 0
    while res > 0 and res <> 1 and res <> 89:
        res = sum([int(n)**2 for n in str(res)])
        #steps += 1
    #print steps
    return res
# print(euler_92(1, 2000000))
# print(euler_92(2000000, 3000000))
# print(euler_92(3000000, 4000000))
# print(euler_92(4000000, 5000000))
# print(euler_92(5000000, 6000000))
# print(euler_92(6000000, 7000000))
# print(euler_92(7000000, 8000000))
# print(euler_92(8000000, 9000000))
# print(euler_92(9000000, 10000000))
# 8581146
    
def euler_100():
    t = 1000885953
    b = 0.5*(1+(2*(t**2) - 2*t + 1)**0.5)
    while b != int(b):
        t += 1
        b = 0.5*(1+(2*(t**2) - 2*t + 1)**0.5)
    print t
    print b
euler_100()
# 1000885952

def pandigital_104(strNumber):
    return (''.join(sorted(list(strNumber)))) == '123456789'
def euler_104():
    Fa = 19717556437089196581097595986132868777484357362710277396538804282697604657932286856665006090315514324457397722361
    Fb = 31903676490304597847185685736169548906931858202641803975680844768196795244879691985828019808017263472521442003280
    Fk = Fa + Fb
    k = 541
    strK = str(Fk)
    while(k < 3000):
        k += 1
        Fa = Fb
        Fb = Fk
        Fk = Fa + Fb
        strK = str(Fk)
        front = pandigital_104(strK[0:9])
        back = pandigital_104(strK[-9:])
        #if front or back:
            #print(k)
		if front and back:
			print('Found!')
			print(k)
			return
def euler_206():
    bigGuys = [1020304050607080900,1121314151617181910,1222324252627282920,
                1323334353637383930,1424344454647484940,1525354555657585950,
                1626364656667686960,1727374757677787970,1828384858687888980,
                1929394959697989990]
    for x in bigGuys:
        print x**0.5
euler_206()

def prime_list(upper):
    numbers = [True]*(upper+1)
    numbers[0]=False
    numbers[1]=False
    p = 2
    while p < upper:
        if numbers[p]:
            f = int(p)
            n = f*p
            while n <= upper:
                numbers[n] = False
                f += 1
                n = f*p
        p += 1
    return [i for i in range(0, upper) if numbers[i]]
print(prime_list(500))




