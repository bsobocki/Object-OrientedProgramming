class Fixnum
	
	def czynniki
		tab= []
		for i in 1..self
			if self % i == 0
				tab +=  [i]
			end
		end
		return tab
	end
	
	def ack(y)
		if self == 0
			return y + 1
		elsif y == 0
		   return (self-1).ack(1)
		else 
			return (self-1).ack(self.ack(y-1))
	    end
	end
	
	def doskonala
			self.czynniki.sum-self == self
	end
	
	def slownie
		sl = self.to_s
		s = ""
		i = 0
		while i < sl.length
			s+= case sl[i]
				when '0'
					"zero "
				when '1' 
					"jeden "
				when '2' 
				    "dwa "
				when '3'
					"trzy "
				when '4' 
					"cztery "
				when '5' 
					"piec "
				when '6'
					"szesc "
				when '7' 
					"siedem "
				when '8'
					"osiem "
				when '9' 
					"dziewiec "
			end
			i += 1
		end
		return s
	end
	
end

puts "  "
puts "czynniki dla 6: #{6.czynniki.to_s}"
puts "czynniki dla 28: #{28.czynniki.to_s}"
puts "Funkcja Ackermann'a dla n=2 i m=1 wynosi: #{2.ack(1)}"
puts "Czy liczba 6 jest doskonala? #{6.doskonala.to_s}"
puts "Czy liczba 8 jest doskonała? #{8.doskonala.to_s}"
puts "Czy liczba 28 jest doskonala? #{28.doskonala.to_s}"
puts "123 slownie: #{123.slownie}"
puts "1090203 slownie: #{1090203.slownie}"
