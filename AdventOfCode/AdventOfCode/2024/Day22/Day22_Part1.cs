namespace AdventOfCode._2024.Day22
{
    public class Day22_Part1
    {
        public long Run(string input, int count)
        {
            var buyers = input.Split("\r\n");
            var newSecrets = buyers.Select(x => GetSecret(long.Parse(x), count));
                
            return newSecrets.Sum();
        }

        private static long GetSecret(long secretNumber, int count)
        {
            for (var i = 0; i < count; i++)
            {
                secretNumber = NextSecret(secretNumber);
            }

            return secretNumber;
        }

        private static long NextSecret(long secret)
        {
            // Calculate the result of multiplying the secret number by 64
            var result = secret * 64;
            // Then, mix this result into the secret number
            secret = Mix(secret, result);
            // Finally, prune the secret number
            secret = Prune(secret);

            // Calculate the result of dividing the secret number by 32. Round the result down to the nearest integer
            result = secret / 32;
            // Then, mix this result into the secret number
            secret = Mix(secret, result);
            // Finally, prune the secret number
            secret = Prune(secret);

            // Calculate the result of multiplying the secret number by 2048
            result = secret * 2048;
            // Then, mix this result into the secret number
            secret = Mix(secret, result);
            // Finally, prune the secret number
            secret = Prune(secret);

            return secret;
        }

        private static long Mix(long secret, long result)
        {
            // To mix a value into the secret number, calculate the bitwise XOR of the given value and the secret number
            var mixed = secret ^ result;

            // Then, the secret number becomes the result of that operation
            return mixed;
        }

        private static long Prune(long secret)
        {
            // To prune the secret number, calculate the value of the secret number modulo 16777216
            var pruned = secret % 16777216;

            // Then, the secret number becomes the result of that operation
            return pruned;
        }
    }
}