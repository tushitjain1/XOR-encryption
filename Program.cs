using System;
using System.Collections.Generic;

namespace xorcode
{
    class Program
    {
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void Main(string[] args){
          brains(); //calling a method to do everything. This method is the very last method in this file
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string key(){
          Random rand = new Random();  //makes a new object, Random
          int num = rand.Next(0,255); // any number from 0 to 255 so that the max length can be 8 bits
          string bin_key = System.Convert.ToString(num,2); //converts to binary
          if (bin_key.Length != 8){ //adds 0's to make it an 8 bit binary if it isn't
            int to_adds = 8 - bin_key.Length;
            string eight_bits = "";
            for (int pp = 0 ; pp < to_adds; pp++){
              eight_bits += "0";
            }
            bin_key = eight_bits + bin_key; //adds the key after the 0's to complete the 8 bit key
            Console.WriteLine("The key is: {0}", bin_key);
            return(bin_key); // returns key
          }
          Console.WriteLine("The key is: {0}", bin_key); //already 8 bit
          return (bin_key); //provides a randomly generated key if the user wants so. //random key generator
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static List <int> foo(string input){ //converts input from string to denary
          List <int> characters = new List <int>();//each element is a character in denary form
          foreach (char i in input){
            characters.Add(System.Convert.ToInt32(i));
          }
          return (characters);
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static List <string>  binary(List <int> final){ //converts denar input list to binary
          List <string> bin = new List <string>(); //new list where each element is a char of the input string in binary
          foreach (int x in final){
            int y = Convert.ToInt32(x);
            string converter = Convert.ToString(y,2);//convderts to binary
            if (converter.Length != 8){ //makes sure the element is always an 8 bit value
              int to_add = 8 - converter.Length;
              string eight_bit = "";
              for (int p = 0 ; p < to_add; p++){
                eight_bit += "0";
              }
              eight_bit += converter;
              bin.Add(eight_bit);
            }
            else{
              bin.Add(converter);
            }
          }
          return(bin); //returns the binary list
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string xor(char g,char h){//basic xor gate
          if (g == h){
            return "0";
          }
          else{
            return "1";
          }
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static List <string> encrypting(List <string> input, string key_to_work_with){//encrypts the input using key, key could be inputed or randomly generated.
          List <string> output = new List <string>();//a list with each element as an encrypted character in binary
          foreach(string q in input){
            var counter = 0;
            string bi_stander = "";
            foreach (char µ in q){
              bi_stander += xor(µ,key_to_work_with[counter]);//uses xor gate to encrypt the list of input elements with the binary key
              counter++;
            }
            output.Add(bi_stander);
          }
          return output;
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static int denary(int nn,int bb){//logic to convert binary to denary using reccursion
          if (nn / 10 > 0 ){
            int yy = (nn % 10) * bb;
            return (yy + denary(nn/10,bb*2));
          }
          else {
            return(nn % 10) * bb;
          }
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string back_to_string(List <int> l){//logic to convert denary into ascii
          string final_output = "";
          foreach (int c in l){
            char lmn = (char)c;
            char lm = Convert.ToChar(lmn);
            final_output += lm;
          }
          return final_output;
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void brains(){//controls every move and gives the output
          Console.WriteLine("Enter string to be encrypted:");
          string _input_ = Console.ReadLine();//input
          var temp_list = binary(foo(_input_));//converts input to denary into binary
          Console.WriteLine("1. Type in the letter 'a' if u want a random key.");//option for random key
          Console.WriteLine("2. Type in the letter 'b' if u want to type in your key.");//opiton user to input a key
          string decision = Console.ReadLine();
          List <string> encrypted = new List <string>();
          if (decision == "a"){
            encrypted = encrypting(temp_list,key());//encrypts input with random key
          }
          else if (decision == "b"){
            Console.WriteLine("Type in your key:");
            string keyy = Console.ReadLine();
            encrypted = encrypting(temp_list,keyy);
          }
          else{
            Console.WriteLine("False input");
          }
          List <int> ran_out = new List <int>();
          foreach (string zz in encrypted){
            ran_out.Add(denary(Convert.ToInt32(zz),1));
          }
          Console.WriteLine("The encrypted string is: {0}",back_to_string(ran_out));
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
