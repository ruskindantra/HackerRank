#!/bin/ruby

def get_uniform_strings_weights(s)
  alphabets = ('a'..'z').to_a
  alphabets_hash = Hash[alphabets.map.with_index.to_a]
  weights = Hash[]

  previous_char = nil
  current_weight = 0

  s.split('').each_with_index do |character, _i|
    alphabet_weight = alphabets_hash[character] + 1

    if previous_char.nil? || previous_char != character
      previous_char = character
      current_weight = alphabet_weight
      weights[current_weight] = "Yes"
    else
      current_weight += alphabet_weight
      weights[current_weight] = "Yes"
    end
  end

  weights
end

s = gets.strip
weights = get_uniform_strings_weights(s)
n = gets.strip.to_i
for a0 in (0..n - 1)
  x = gets.strip.to_i

  if weights[x] == "Yes"
    puts 'Yes'
  else
    puts 'No'
  end
end
