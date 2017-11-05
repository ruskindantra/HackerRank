#!/bin/ruby

s = gets.strip

number_of_words = 1
s.split("").each_with_index do |character, i|
  if /[[:upper:]]/.match(character)
    number_of_words += 1
  end
end

puts number_of_words