def Add(x,y):
	return x + y; 

def SayHello(name):
	return "Hello " + name + ", from Python"

def Factorial(n):
	if n <= 1:
		return 1
	return n * Factorial(n-1)
