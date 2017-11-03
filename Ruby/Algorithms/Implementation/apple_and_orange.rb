#!/bin/ruby

def find_oranges_and_apples(s, t, a, b, oranges, apples)
  apples_on_house = 0
  oranges_on_house = 0

  apples.each_with_index {|apple, i|
    next if apple < 0
    fallen_position = a + apple
    if fallen_position >= s && fallen_position <= t
      apples_on_house += 1
    end
  }

  oranges.each_with_index {|orange, i|
    next if orange > 0
    fallen_position = b + orange
    if fallen_position >= s && fallen_position <= t
      oranges_on_house += 1
    end
  }

  result = []
  result.push apples_on_house
  result.push oranges_on_house
end

s,t = gets.strip.split(' ')
s = s.to_i
t = t.to_i
a,b = gets.strip.split(' ')
a = a.to_i
b = b.to_i
m,n = gets.strip.split(' ')
m = m.to_i
n = n.to_i
apple = gets.strip
apple = apple.split(' ').map(&:to_i)
orange = gets.strip
orange = orange.split(' ').map(&:to_i)
result = find_oranges_and_apples(s, t, a, b, orange, apple)
print result.join("\n")
