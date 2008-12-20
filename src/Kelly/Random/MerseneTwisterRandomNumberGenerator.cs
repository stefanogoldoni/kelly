using System;
using Kelly.Math;

namespace Kelly.Random {
	public class MersenneTwisterRandomNumberGenerator : IRandomNumberGenerator {
		public MersenneTwisterRandomNumberGenerator() : this(Environment.TickCount) {
		}

		public MersenneTwisterRandomNumberGenerator(int seed) {
			State = new uint[624];

			Init((uint)seed);
		}

		private static uint UpperBit(uint value) {
			return value & 0x80000000;
		}

		private static uint LowerBits(uint value) {
			return value & 0x7fffffff;
		}

		protected uint[] State { get; private set; } /* the array for the state vector  */
		private int _index;

		private void Init(uint seed) {
			State[0] = seed;
			for(var i = 1u; i < State.Length; i++) {
				State[i] = (uint)(1812433253UL * (State[i - 1] ^ (State[i - 1] >> 30)) + i);
			}
		}

		protected virtual void GenerateNumbers() {
			for (var i = 0; i < State.Length; i++) {
				var y = UpperBit(State[i]) + LowerBits(State[(i + 1) % State.Length]);

				State[i] = State[(i + 397) % State.Length] ^ (y >> 1);

				if (y.IsEven()) {
					State[i] ^= 0x9908b0df;
				}
			}			
		}

		/* generates a random number on [0,0xffffffff]-interval */
		private uint NextUInt() {
			if (_index == 0) {
				GenerateNumbers();
			}

			var value = State[_index];
			_index = (_index + 1) % State.Length;

			return Temper(value);
		}

		private static uint Temper(uint value) {
			value ^= (value >> 11);
			value ^= (value << 7) & 0x9d2c5680;
			value ^= (value << 15) & 0xefc60000;
			value ^= (value >> 18);

			return value;
		}

		public double Next() {
			return NextUInt() / 4294967295.0f; 
		}

///* generates a random number on [0,0x7fffffff]-interval */
//long genrand_int31(void)
//{
//    return (long)(genrand_int32()>>1);
//}

///* generates a random number on [0,1]-real-interval */
//double genrand_real1(void)
//{
//    return genrand_int32()*(1.0/4294967295.0); 
//    /* divided by 2^32-1 */ 
//}

///* generates a random number on [0,1)-real-interval */
//double genrand_real2(void)
//{
//    return genrand_int32()*(1.0/4294967296.0); 
//    /* divided by 2^32 */
//}

///* generates a random number on (0,1)-real-interval */
//double genrand_real3(void)
//{
//    return (((double)genrand_int32()) + 0.5)*(1.0/4294967296.0); 
//    /* divided by 2^32 */
//}

///* generates a random number on [0,1) with 53-bit resolution*/
//double genrand_res53(void) 
//{ 
//    unsigned long a=genrand_int32()>>5, b=genrand_int32()>>6; 
//    return(a*67108864.0+b)*(1.0/9007199254740992.0); 
//} 
	}
}
