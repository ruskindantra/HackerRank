#!/bin/ruby

string_to_match = "hackerrank"

q = gets.strip.to_i
for a0 in (0..q-1)
  s = gets.strip

  char_to_match = 0

  matched_string = "NO"
  s.split("").each_with_index do |character, i|
    if character == string_to_match[char_to_match]
      char_to_match += 1

      if char_to_match > 9
        matched_string = "YES"
        break
      end
    end
  end

  puts matched_string

end

