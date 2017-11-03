#!/bin/ruby

def solve(grades)
  results = []
  grades.each_with_index do |x, _i|
    if x % 5 >= 3
      scaled_result = x + (5 - x % 5)
      scaled_result = x if scaled_result < 40
      results.push scaled_result
    else
      results.push x
    end
  end
  results
end

n = gets.strip.to_i
grades = Array.new(n)
for grades_i in (0..n - 1)
  grades[grades_i] = gets.strip.to_i
end
result = solve(grades)
print result.join("\n")
