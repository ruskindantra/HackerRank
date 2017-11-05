#!/bin/ruby

def unique_characters_in_string(value)
  unique_characters = []
  value.split("").each_with_index do |character, i|
    if !unique_characters.include? character
      unique_characters.push character
    end
  end

  unique_characters
end

def alternating_characters(value)
  prev_char = nil
  value.split("").each_with_index do |character, i|
    if prev_char == nil
      prev_char = character
    else
      if prev_char == character
        return false
      else
        prev_char = character
      end
    end
  end
  return true
end

len = gets.strip.to_i
s = gets.strip

unique_characters = unique_characters_in_string(s)

potential_solutions = []

if unique_characters.length > 2
  combinations_to_find = unique_characters.length - 2
  unique_combinations = unique_characters.combination(combinations_to_find).to_a

  unique_combinations.each_with_index do |characters, i|
    temp_str = s.dup

    characters.each_with_index do|character, j|
      temp_str.tr!(character, '')
    end
    if unique_characters_in_string(temp_str).length == 2
      if alternating_characters(temp_str)
        potential_solutions.push temp_str
      end
    end
  end
else
  if unique_characters.length == 2
    if alternating_characters(s)
      potential_solutions.push s
    end
  end
end

if !potential_solutions.empty?
  #puts potential_solutions.join " "
  #puts "\n"
  puts potential_solutions.max_by(&:length).length
else
  puts 0
end