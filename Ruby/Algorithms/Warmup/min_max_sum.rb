#!/bin/ruby

def min_max_sum(items)
  maxSum = nil
  minSum = nil

  indexToSkip = 0

  while indexToSkip < 5

    tempSum = 0
    items.each_with_index {|x, i|
      begin
        if i == indexToSkip
          next
        end

        tempSum += x
      end
    }

    if maxSum == nil || maxSum < tempSum
      maxSum = tempSum
    end

    if minSum == nil || minSum > tempSum
      minSum = tempSum
    end

    indexToSkip+=1
  end

  returnArr = []
  returnArr.push minSum
  returnArr.push maxSum
  returnArr
end

arr = gets.strip
arr = arr.split(' ').map(&:to_i)
result = min_max_sum(arr)
print result.join(' ')
