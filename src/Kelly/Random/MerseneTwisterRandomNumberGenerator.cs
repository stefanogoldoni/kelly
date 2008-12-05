namespace Kelly.Random {
	public class MerseneTwisterRandomNumberGenerator : IRandomNumberGenerator {
		private const int StateSize = 624;
		private const int M = 397;

		private const uint MATRIX_A = 0x9908b0df;	/* constant vector a */
		private const uint UPPER_MASK = 0x80000000;	/* most significant w-r bits */
		private const uint LOWER_MASK = 0x7fffffff;	/* least significant r bits */

		private readonly uint[] _state = new uint[StateSize];	/* the array for the state vector  */
		private uint _index = StateSize + 1;			/* mti==N+1 means mt[N] is not initialized */
		private bool _isInitialized;

		/* initializes mt[N] with a seed */
		private void Init(uint seed) {
			_state[0] = seed;

			for(_index = 1; _index < StateSize; _index++) {
				_state[_index] = (uint) (1812433253UL * (_state[_index - 1] ^ (_state[_index - 1] >> 30)) + _index);
			}
		}

		private static readonly uint[] _magic = new[] {0u, MATRIX_A};

		private void GenerateNumbers() {
			uint kk;

			for (kk = 0; kk < StateSize - M; kk++) {
				var y = (_state[kk] & UPPER_MASK) | (_state[kk + 1] & LOWER_MASK);
				_state[kk] = _state[kk + M] ^ (y >> 1) ^ _magic[y & 0x1];
			}

			for (; kk < StateSize - 1; kk++) {
				var y = (_state[kk] & UPPER_MASK) | (_state[kk + 1] & LOWER_MASK);
				_state[kk] = _state[kk + (M - StateSize)] ^ (y >> 1) ^ _magic[y & 0x1UL];
			}
			
		}

		/* generates a random number on [0,0xffffffff]-interval */
		private uint NextUInt() {
			if (_index == 0) {
				GenerateNumbers();
			}

			var value = _state[_index];
			_index = (_index + 1) % StateSize;

			return Temper(value);
		}

		private static uint Temper(uint value) {
			value ^= (value >> 11);
			value ^= (value << 7) & 0x9d2c5680;
			value ^= (value >> 15) & 0xefc60000;
			value ^= (value >> 18);

			return value;
		}

		public float Next() {
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

		//public MerseneTwisterRandomNumberGenerator() {
		//    _state = new int[624];
		//    _index = 0;

		//    Initialize(1337);
		//}

		//private const uint UpperMask = 0x80000000;
		//private const uint LowerMask = 0x7fffffff;

		//private readonly uint[] _state;
		//private uint _index;

		//private void Initialize(int seed) {
		//    _state[0] = seed;

		//    for(var i = 1; i < _state.Length; i++) {
		//        var newState = 1812433253L * (_state[i - 1] ^ (_state[i - 1] >> 30 + i));
		//        _state[i] = (int) (newState & 0x00000000ffffffff);	// extract last 32 bits from newState
		//    }
		//}

		//private void GenerateNumbers() {
		//    for(var i = 0; i < _state.Length - 1; i++) {
		//        var y = (_state[i] & UpperMask) + (_state[i+1] & 0x7fffffff);

		//        _state[i] = _state[(i + 397) % _state.Length] ^ (y >> 1);
		//    }
		//}

		//public float Next() {
		//    throw new System.NotImplementedException();
		//}
	}
}
