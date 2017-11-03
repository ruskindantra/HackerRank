#!/bin/ruby

def getTotalX(a, b)

  all_common_factors = []

  for j in 1..100
    not_a_factor = false
    b.each_with_index {|b_item, i |
      if b_item % j != 0
        not_a_factor = true
        break
      end
    }
    all_common_factors.push j if !not_a_factor
  end

  all_common_divisors = []

  all_common_factors.each_with_index {|item, i|
    divisor_found = true
    a.each_with_index {|a_item, j|
      if item % a_item != 0
        divisor_found = false
      end
    }
    all_common_divisors.push item if divisor_found
  }

  # print all_common_divisors.join(",")

  # puts "\n"

  return all_common_divisors.length
end

n, m = gets.strip.split(' ')
n = n.to_i
m = m.to_i
a = gets.strip
a = a.split(' ').map(&:to_i)
b = gets.strip
b = b.split(' ').map(&:to_i)
total = getTotalX(a, b)
puts total

