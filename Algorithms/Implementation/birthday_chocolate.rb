#!/bin/ruby

def solve(n, s, d, m)
  number_ways_split = 0
  number_pieces = n - m + 1

  s.each_with_index do |s_item, i|
    break if i == number_pieces

    running_total = s_item

    start_index = i + 1
    end_index = i + m - 1
    for j in start_index..end_index
      running_total += s[j]
    end
    number_ways_split += 1 if running_total == d
  end
  number_ways_split
end

n = gets.strip.to_i
s = gets.strip
s = s.split(' ').map(&:to_i)
d, m = gets.strip.split(' ')
d = d.to_i
m = m.to_i
result = solve(n, s, d, m)
puts result
