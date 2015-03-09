#** Python **

# ZEN OF PYTHON
# Beautiful is better than ugly.
# Explicit is better than implicit.
# Simple is better than complex.
# Complex is better than complicated.
# Flat is better than nested.
# Sparse is better than dense.
# Readability counts.
# Special cases aren't special enough to break the rules.
# Although practicality beats purity.
# Errors should never pass silently.
# Unless explicitly silenced.
# In the face of ambiguity, refuse the temptation to guess.
# There should be one —and preferably only one— obvious way to do it.
# Although that way may not be obvious at first unless you're Dutch.
# Now is better than never.
# Although never is often better than right now.
# If the implementation is hard to explain, it's a bad idea.
# If the implementation is easy to explain, it may be a good idea.
# Namespaces are one honking great idea—let's do more of those!
# We're all consenting adults here

#types: 
str(x), float(x), int(x), int(str, base)
#numbers: 
bin(x), oct(x), hex(x)
#input
raw_input("Text?") #Py 2.X
input("Text") #Py 3.X

if x>0:
  pass
elif x==0:
  pass
else:
  pass

def function_name(argument,optional_argument=defaultvalue):
	return argument
#function_name(value)
#function_name(argument=value)
#function_name(argument=value, nondefaultvalue)
#function_name(optional_argument=nondefaultvalue, argument=value)
def concat(*args, separator=", ")
	return separator.join(args)

#Strings
string = ""
string = """ Multi
             line
			 string """
string.upper()
string.lower()
string[i:j]
len(string)
string = str1 + str2
"format string (%s, %s, %s)" % (var1, var2, var3)
#String based on dictionary
values = {'name': name, 'messages': messages}
print ('Hello %(name)s, you have %(messages)i '
       'messages' % values)

#Lists
list = [ "item", "item" , "..."]
list[:j] #= 0..j
list[i:] #= i..end
list.append("item")
list.insert(2,"item")
list.sort()
sorted(list)
len(list)
list.pop(2)
list.remove(1)
del(list[0])
list = lst1 + lst2
listO = ["O"]*5
lists = string.split(",")
print "__".join(list)
var_item not in var_list
colors = ['red', 'blue', 'green', 'yellow']
print 'Choose', ', '.join(colors[:-1]), \
      'or', colors[-1]
#list comprehension:
evens_to_50 = [i**2 for i in range(51) if i % 2 == 0]
new_list = [fn(item) for item in a_list
            if condition(item)]
#generator expressions: Doesn't create the List, iterates values
#    Use a list comprehension when a computed list is the desired end result.
#    Use a generator expression when the computed list is just an intermediate step.
total = sum(num * num for num in xrange(1, 101))
#list slicing:
list[start:end:stride]
backward = list[::-1]

#Dictionary
dictionary = {key:value, ...}
dictionary[key] = newvalue
del dictionary[key]
dictonary.remove(key)
dict.items() 
dict.keys()
dict.values()

#Importing
import module
module.name

import long_module_name as mod
mod.name

from module import name
name

from module import * # NEVER!

#Loop
for item in list:
    action
for key in dictionary:
    print dictionary[key]
for letter in string:
    action
for i in range(len(list)):
    print list[i]
for index, item in enumerate(list):
    print index, item
for a, b in zip(list_a, list_b):
    print a, b
for i in list:
    if i > 10:
	break
else:
	actionAfterEnd-NoBreak
for i in range(n):
    if num%2 == 0:
	print("Even", num)
        continue #Skip rest of code and start new iteration of for
    print("Odd", num)

start = 3
stop = 74
step = 4	
print range(stop)
print range(start, stop)
print range(start, stop, -step)
print range(start, stop, step)[::-1]

while x>1:
	action
	break
else:
	action
#append prints:
	print "x",
	print

#Function Factory:
def make_incrementor(n):
    return lambda x: x + n
f = make_incrementor(40)
#f(1) ====>>> 41

filter(lambda x: x % 3 == 0, my_list)

#Documentation:
def functionX():
    """ This is documentation """
    pass #Placeholder

#Bitwise:
 5 >> 4  # Right Shift, move bits to the right 4 spots, = 0
 5 << 1  # Left Shift, move bits to the left 1 spot, = 10
 8 & 5   # Bitwise AND
 9 | 4   # Bitwise OR
 12 ^ 42 # Bitwise XOR
 ~88     # Bitwise NOT
binX = 0b1010011010 #Binary Format

#Classes
class NameOfClass(object):
    member_variable = value
    def __init__(self, arg):
	    self.arg = arg
    def __repr__(self): #Text representation
        return "[%s]" % (self.arg)
	def __cmp__(self, other): #comparison
        return cmp(self.arg, other.arg)	
    def function(self):
	print self.arg
object_class = Name("arg")
object_class.function()

class DerivedClass(Base):
   def m(self):
       return super(Derived, self).m()

#Errors
try:
    f = open("test.txt", "w") # r=read, w=write, r+=readandwrite
    f.write("Test Data")
except IOError as e:
    print "IO error:", e
except:
    print "unknown error"
else:
    print "success"
finally:
    f.close()
f.read()
f.readline()

with open("text.txt", "w") as textfile:
	textfile.write("Success!")
f.closed #T/F

from urllib2 import urlopen
www_file = urlopen(url).read()

# Make a GET request here and assign the result to response:
import requests
response = requests.get("http://url.com")
#Response codes
print response.status_code
#1xx: You won't see these a lot. The server is saying, "Got it! I'm working on your request."
#2xx: These mean "okay!" The server sends these when it's successfully responding to your request.
#3xx: These mean "I can do what you want, but I have to do something else first." You might see this if a website has changed addresses and you're using the old one; the server might have to reroute the request before it can get you the resource you asked for.
#4xx: These mean you probably made a mistake. The most famous is "404," meaning "file not found": you asked for a resource or web page that doesn't exist.
#5xx: These mean the server goofed up and can't successfully respond to your request.
print response.headers
responsePost = requests.post("http://url.com", data={'key': 'value', 'key2': 'value2'})

import datetime
xdate = date(1999, 12, 21)
hoy = datetime.date.today()
manana = hoy.replace(day=hoy.day+1)
day_of_week = xdate.weekday() # [0 Monday .. 6 Sunday]
date_str = xdate.strftime("%d/%m/%y")
date_iso = xdate.isoformat() # YYYY-MM-DD
date_difference = (date_1 - date_2).days

xtime = datetime.time([hour[, minute[, second[, microsecond[, tzinfo]]]]])
xtime2 = xtime.replace(hour=15)

from datetime import timedelta
xtime3 = xtime + timedelta(hours=3)

#Parsing
from xml.dom import minidom
f = open('pets.txt', 'r')
pets = minidom.parseString(f.read())
f.close()
names = pets.getElementsByTagName('name')
for name in names:
	print name.firstChild.nodeValue
	
import json
from pprint import pprint #Pretty print
f = open('pets.txt', 'r')
pets = json.loads(f.read())
f.close()
pprint(pets)

# ************* New Module Structure ****************
"""module docstring"""

# imports
# constants
# exception classes
# interface functions
# classes
# internal functions & classes

def main(...):
    ...

if __name__ == '__main__':
    status = main()
    sys.exit(status)

# ***************** Packaging *****************
# package/
#     __init__.py
#     module1.py
#     subpackage/
#         __init__.py
#         module2.py
import package.module1
from package.subpackage import module2
from package.subpackage.module2 import name
	
# Style principles
# http://python.net/~goodger/projects/pycon/2007/idiomatic/presentation.html

#*********************************Recipes*********************************

#We often have to initialize dictionary entries before use:
#This is the naïve way to do it:

navs = {}
for (portfolio, equity, position) in data:
    if portfolio not in navs:
        navs[portfolio] = 0
    navs[portfolio] += position * prices[equity]

#dict.get(key, default) removes the need for the test:

navs = {}
for (portfolio, equity, position) in data:
    navs[portfolio] = (navs.get(portfolio, 0)
                       + position * prices[equity])

#Here we have to initialize mutable dictionary values. Each dictionary value will be a list. This is the naïve way:
#Initializing mutable dictionary values:

equities = {}
for (portfolio, equity) in data:
    if portfolio in equities:
        equities[portfolio].append(equity)
    else:
        equities[portfolio] = [equity]

#dict.setdefault(key, default) does the job much more efficiently:
# it means: Set if you need to, then Get

equities = {}
for (portfolio, equity) in data:
    equities.setdefault(portfolio, []).append(equity)

# Create Dictonary based on Two Lists
given = ['John', 'Eric', 'Terry', 'Michael']
family = ['Cleese', 'Idle', 'Gilliam', 'Palin']
pythons = dict(zip(given, family))

# Loop through List of items, add Index
for (index, item) in enumerate(items):
    print index, item



#** JAVASCRIPT **

var objectName = {
	identifier: "value",
	functionName: function(param1) {
		return "action: " + param1;
		}
	}

function ClassName(param1, param2) {
	this.param1 = param1;
	this.param2 = param2;
}

var newObject = ClassName(attr1, attr2);
var newObject2 = ClassName(attr3, attr4);
