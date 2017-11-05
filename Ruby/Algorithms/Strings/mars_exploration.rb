#!/bin/ruby

S = gets.strip

changed_characters = 0

split_sos_messages = S.chars.each_slice(3).to_a.map(&:join)
split_sos_messages.each_with_index do|item, i|
  if item[0] != 'S'
    changed_characters += 1
  end

  if item[1] != 'O'
    changed_characters += 1
  end

  if item[2] != 'S'
    changed_characters += 1
  end
end

#puts split_sos_messages.join " "

#puts "\n"
puts changed_characters