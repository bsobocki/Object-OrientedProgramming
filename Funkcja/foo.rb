class Funkcja
 
	attr_accessor :foo
 
	def initialize(&block)
		@foo = Proc.new(&block)
	end
	
	def value(x)
		 @foo.call x
	end
	
	# liczby calkowite z przedzialu a do b ktore po podstawieniu daja wynik oddalony od 0 o nie wiecej niz e
	def zerowe(l, p, e)
		temp = []
		a = l
		b = p
		dl = (b - a).abs
		
		while dl > 0.00001
			if value(a).abs <= e 
				temp += [a.round(3)]
			end
			a+=0.0000001
			dl = (b-a).abs
			end
		temp.uniq

	end
	
	#obliczane z pomocą Sumy Riemanna
	def pole(a, b)
		e = 0.000001 * (b - a).abs
		s = 0
		for i in 0..999999
			s += value(a+i*e+e/2) * e
		end
		s.round(8)
	end
	
	#f'(x) = lim h->0    f(x + 1) - f(x) / h     || tutaj h = 0.0000001
	def poch(x)
		temp = ( value(x + 0.0000001) - value(x) ) / 0.0000001 
		temp.round(5)
	end
	
end


# ------TEST------
puts ""
puts " ---obliczenia--- " ;puts ""
# f(x) = x^3  
# f'(x) = 3x^2 
# S f(x) dx = ( x^4 )/ 4
f = Funkcja.new{|x| x*x*x}
puts f.value(5)
puts f.poch(5)
puts f.pole(2,4)

puts ""
puts " ---obliczenia2--- " ;puts ""
# f'(x) = 2x
f = Funkcja.new{|x| x*x}
puts f.poch(5)
puts f.pole(0,1)

puts ""
puts " ---obliczenia3--- " ;puts ""
g = Funkcja.new{|x| (x+1)*(x*x - 4)*(x + 0.5)}
puts g.zerowe(-2, 4, 0.0001).to_s
g = Funkcja.new{|x| x*(x*x - 2)*(x*x*x - 1)}
puts g.zerowe(-5, 5,  0.0001).to_s

puts ""
puts " ---obliczenia4--- " ;puts ""
# g(x) = sin x
# g'(x) = cos x
g = Funkcja.new{|x| Math.sin(x)}
puts g.poch(0)
puts g.poch(Math::PI/2)
puts g.poch(Math::PI)