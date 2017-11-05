def unique_characters_in_string(value)
  unique_characters = []
  value.split("").each_with_index do |character, i|
    if character == ' '
      next
    end

    if !unique_characters.include? character.downcase
      unique_characters.push character.downcase
    end
  end

  unique_characters
end

s = gets.strip
unique_characters = unique_characters_in_string(s)

if unique_characters.length == 26
  puts "pangram"
else
  puts "not pangram"
end