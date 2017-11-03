#!/bin/ruby

def birthdayCakeCandles(n, ar)
  maxCandle = nil
  ar.each_with_index {|x, i|
    if maxCandle == nil || maxCandle < x
      maxCandle = x
    end
  }
  indices = ar.each_index.select{|i| ar[i] == maxCandle}

  return indices.length
end

n = gets.strip.to_i
ar = gets.strip
ar = ar.split(' ').map(&:to_i)
result = birthdayCakeCandles(n, ar)
puts result