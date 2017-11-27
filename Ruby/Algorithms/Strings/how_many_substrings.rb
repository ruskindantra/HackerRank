#!/bin/ruby

def prune_duplicates(str_array)
  unique_values = []
  for i in 0..str_array.length - 1
    unique_values.push str_array[i] unless unique_values.include?(str_array[i])
  end
  unique_values
end

n, q = gets.strip.split(' ')
n = n.to_i
q = q.to_i
s = gets.strip
for a0 in (0..q - 1)
  left, right = gets.strip.split(' ')
  left = left.to_i
  right = right.to_i

  sub_string = s.slice(left..right)
  all_combinations = []

  sub_string.chars.to_a.each_with_index do |c, i|
    inner_index = i + 1
    all_combinations.push c

    inner_sub_string = c
    for j in inner_index..sub_string.length - 1
      inner_sub_string += sub_string[j]
      all_combinations.push inner_sub_string
    end
  end

  all_combinations = prune_duplicates all_combinations

  puts all_combinations.join ', '
  puts "\n"
  puts all_combinations.length
end
