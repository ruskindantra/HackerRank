#!/bin/ruby

def kangaroo(x1, v1, x2, v2)
  no_string = 'NO'

  return no_string if x2 > x1 && v2 >= v1

  lhs = x1 - x2
  rhs = v2 - v1

  number_of_steps = lhs.to_f / rhs

  if number_of_steps % 1 == 0
    #printf 'Steps=%s', number_of_steps.to_i
    #puts "\n"
    return 'YES'
  end

  no_string
end

x1, v1, x2, v2 = gets.strip.split(' ')
x1 = x1.to_i
v1 = v1.to_i
x2 = x2.to_i
v2 = v2.to_i
result = kangaroo(x1, v1, x2, v2)
puts result
