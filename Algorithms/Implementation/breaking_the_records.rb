#!/bin/ruby

def getRecord(s)
  number_times_score_increased = 0
  number_times_score_decreased = 0
  max_score = nil
  min_score = nil

  s.each_with_index do |s_item, i|
    if i == 0
      max_score = s_item
      min_score = s_item
    else
      if s_item > max_score
        max_score = s_item
        number_times_score_increased += 1

      end
      if s_item < min_score
        min_score = s_item
        number_times_score_decreased += 1

      end
    end
  end

  result = [number_times_score_increased, number_times_score_decreased]
  result
end

n = gets.strip.to_i
s = gets.strip
s = s.split(' ').map(&:to_i)
result = getRecord(s)
print result.join(' ')
