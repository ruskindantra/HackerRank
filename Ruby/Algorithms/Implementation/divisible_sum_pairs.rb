#!/bin/ruby

def divisibleSumPairs(n, k, ar)
  pairs = 0
  ar.each_with_index do |item, i|
    ar.each_with_index do |inner_item, j|
      if i <= j
        next
      end

      pairs += 1 if ((item + inner_item) % k).zero?
    end
  end
  pairs
end

n, k = gets.strip.split(' ')
n = n.to_i
k = k.to_i
ar = gets.strip
ar = ar.split(' ').map(&:to_i)
result = divisibleSumPairs(n, k, ar)
puts result;

