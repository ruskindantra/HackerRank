#!/bin/ruby

def super_reduced_string(s)
  none_found = false
  last_char = false
  until none_found && last_char
    s.split("").each_with_index do |character, i|
      if i == s.length - 1
        last_char = true
        none_found = true
        break
      end

      first_char = character
      second_char = s[i+1]

      if first_char == second_char
        none_found = false
        s.slice!(i)
        s.slice!(i)

        # exit because string is empty
        if s.empty?
          none_found = true
          last_char = true
        end

        break
      else
        none_found = true
      end
    end
    #puts s
    #puts "\n"
  end

  if s.empty?
    'Empty String'
  else
    s
  end
end

s = gets.strip
result = super_reduced_string(s)
puts result

