#!/bin/ruby

def solve(a0, a1, a2, b0, b1, b2)
  arr = []
  aWins = 0
  bWins = 0
  if (a0 > b0)
    aWins += 1
  elsif (a0 < b0)
    bWins += 1
  end
  if (a1 > b1)
    aWins += 1
  elsif (a1 < b1)
    bWins += 1
  end
  if (a2 > b2)
    aWins += 1
  elsif (a2 < b2)
    bWins += 1
  end

  arr.push aWins
  arr.push bWins

  return arr
end

a0, a1, a2 = gets.strip.split(' ')
a0 = a0.to_i
a1 = a1.to_i
a2 = a2.to_i
b0, b1, b2 = gets.strip.split(' ')
b0 = b0.to_i
b1 = b1.to_i
b2 = b2.to_i
result = solve(a0, a1, a2, b0, b1, b2)
print result.join(' ')
