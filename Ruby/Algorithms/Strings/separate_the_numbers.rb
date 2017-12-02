#!/bin/ruby
#
q = gets.strip.to_i
for a0 in (0..q-1)
  s = gets.strip

  if s.length <= 1 || s.start_with?("0")
    puts 'NO'
    next
  end

  substring_length = 1
  max_substring_length = s.length / 2
  perfect_string_found = true

  # 110111 (max substring length = 3)
  # 9991000 (max substring length = 3)

  i = substring_length
  loop do

    temp_i = i

    numbers = []
    prev_number = nil
    perfect_string_found = true # always start assuming it's a perfect string
    j = 0
    loop do
      curr_number = s[j, i].to_i
      if prev_number.nil? || prev_number == curr_number - 1
        prev_number = curr_number
        numbers.push curr_number
      else
        perfect_string_found = false
        break
      end

      j += i

      # done after j is incremented
      if curr_number.to_s.end_with? ("9" * i)
        i += 1 # we have a number ending in 9, perfect string will have next number with 1 more character
      end

      break if j > s.length - 1
    end

    if perfect_string_found
      puts 'YES %i' % numbers[0]
      break
    else
      # no perfect string found, reset i
      i = temp_i
    end

    i += 1
    break if i > max_substring_length
  end

  unless perfect_string_found
    puts 'NO'
  end

end