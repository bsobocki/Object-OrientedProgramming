class Zaszyfrowane

	attr_accessor :szyfr
	
	def initialize (slowo, klucz)
		@szyfr = ""
		i = 0
		while i < slowo.length
			@szyfr += klucz[slowo[i]]
			i+=1
		end
	end
	
	def odszyfruj(klucz)
		i = 0
		s = ""
		while i < szyfr.length
			s += klucz.key(szyfr[i])
			i+=1
		end
		return Jawna.new(s)
	end

end

class Jawna

	attr_accessor :slowo

	def initialize(s)
		@slowo = s
	end
	
	def zaszyfruj(klucz)
		return Zaszyfrowane.new(slowo, klucz)
	end
	
end

klucz = {  's' => 'r', 
				'e' => 'g',
				'l' => 'l',
				'o' => 'p',
				'w' => 'v'}
				
jaw = Jawna.new("slowo")
szyf = jaw.zaszyfruj(klucz)
puts "
wyraz do zaszyfrowania : \"slowo\"
klucz #{klucz.to_s}
wartosc wyrazenia po zaszyfrowaniu: #{szyf.szyfr}"
jaw = szyf.odszyfruj(klucz)
puts "wartosc wyrazenia po odszyfrowaniu: #{jaw.slowo}"
