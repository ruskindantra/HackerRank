#!/bin/ruby

def migratoryBirds(n, ar)
  bird_types = [0, 0, 0, 0, 0] # array for 5 bird types

  ar.each_with_index do |item, i|
    bird_types[item-1] += 1
  end

  max_val = bird_types.max
  bird_types.each_index.select{|i| return i+1 if bird_types[i] == max_val}
end

n = gets.strip.to_i
ar = gets.strip
ar = ar.split(' ').map(&:to_i)
result = migratoryBirds(n, ar)
puts result

