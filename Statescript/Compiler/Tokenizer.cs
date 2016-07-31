
#line 1 "Tokenizer.rl.cs"
// This file is AUTOGENERATED with RAGEL
// !!DO NOT EDIT!! Change the RL file and compile with Ragel
// http://www.colm.net/open-source/ragel/
// This RL file is the RAGEL file that generates the parser
// Build and test:
// alias mcs=/Library/Frameworks/Mono.framework/Versions/Current/bin/mcs
// ragel -A Parser.rl && mcs *.cs -define:RAGEL_TEST && mono parser.exe
// ragel -o Parser.cs -A ParserDefinition.rl.cs && mcs Parser.cs -define:RAGEL_TEST && mono parser.exe
// make sure AstNode.cs and AstParam.cs are in the same folder
namespace Statescript.Compiler
{
   using System;
   using System.Collections.Generic;

   public enum TokenType
   {
     Keyword,
     Identifier,
     Value,
     TransitionValue,
     MessageValue,
     Operator,
     NewLine
   }

   public enum TokenOperator
   {
     Set,
     Transition
   }

   public struct Token
   {
     public string Value;
     public int StartIndex;
     public int Length;
     public int LineNumber;
     public TokenType TokenType;
     public TokenOperator Operator;
   }

   public class Tokenizer
   {
      int _lineNumber = 0;
      int _tokenStart = 0;
      private List<Token> _tokens;
      char[] _data;
      // ragel properties
      private int cs;
      int p;

      private void StartToken()
      {
        _tokenStart = p;
      }

      private void log(string msg) {
        Console.WriteLine(string.Format("{0} {1}", p, msg));
      }

      private void logEnd(string msg) {
        var token = new String(_data, _tokenStart, p - _tokenStart);
        Console.WriteLine(string.Format("{0} {1}: {2}", p, msg, token));
      }

      private void EmitOperator(TokenOperator tokenOperator) {
        _tokens.Add(new Token {
          LineNumber = _lineNumber,
          Operator = tokenOperator,
          TokenType = TokenType.Operator
        });
      }

      private void EmitToken(TokenType tokenType) {
        var token = new Token {
          LineNumber = _lineNumber,
          StartIndex = _tokenStart,
          Length = p - _tokenStart,
          Value = new String(_data, _tokenStart, p - _tokenStart),
          TokenType = tokenType
        };

        if (tokenType == TokenType.TransitionValue
            || tokenType == TokenType.Value
            || tokenType == TokenType.MessageValue) {
          // remove quotes
          token.StartIndex = token.StartIndex + 1;
          token.Length = token.Length - 2;
        }

        _tokens.Add(token);
      }

      private void EmitNewLine() {
        _tokens.Add(new Token {
          LineNumber = _lineNumber,
          TokenType = TokenType.NewLine
        });
      }

      
#line 105 "tmp/Tokenizer.cs"
static readonly sbyte[] _Tokenizer_actions =  new sbyte [] {
	0, 1, 0, 1, 1, 1, 2, 1, 
	3, 1, 4, 1, 5, 1, 6, 1, 
	7, 2, 2, 1, 2, 5, 6, 2, 
	7, 0
};

static readonly sbyte[] _Tokenizer_key_offsets =  new sbyte [] {
	0, 0, 4, 13, 22, 30, 41, 45, 
	46, 51, 56, 61, 69, 70, 75, 83, 
	85
};

static readonly char[] _Tokenizer_trans_keys =  new char [] {
	'\u0020', '\u0040', '\u0009', '\u000d', '\u0020', '\u0040', '\u005f', '\u0009', 
	'\u000d', '\u0041', '\u005a', '\u0061', '\u007a', '\u0020', '\u0040', '\u005f', 
	'\u0009', '\u000d', '\u0041', '\u005a', '\u0061', '\u007a', '\u0020', '\u005f', 
	'\u0009', '\u000d', '\u0041', '\u005a', '\u0061', '\u007a', '\u0020', '\u002d', 
	'\u005f', '\u0009', '\u000d', '\u0030', '\u0039', '\u0041', '\u005a', '\u0061', 
	'\u007a', '\u0020', '\u002d', '\u0009', '\u000d', '\u003e', '\u0020', '\u0022', 
	'\u0027', '\u0009', '\u000d', '\u0020', '\u0022', '\u0027', '\u0009', '\u000d', 
	'\u005f', '\u0041', '\u005a', '\u0061', '\u007a', '\u0022', '\u005f', '\u0030', 
	'\u0039', '\u0041', '\u005a', '\u0061', '\u007a', '\u000a', '\u005f', '\u0041', 
	'\u005a', '\u0061', '\u007a', '\u0027', '\u005f', '\u0030', '\u0039', '\u0041', 
	'\u005a', '\u0061', '\u007a', '\u000a', '\u000d', (char) 0
};

static readonly sbyte[] _Tokenizer_single_lengths =  new sbyte [] {
	0, 2, 3, 3, 2, 3, 2, 1, 
	3, 3, 1, 2, 1, 1, 2, 2, 
	0
};

static readonly sbyte[] _Tokenizer_range_lengths =  new sbyte [] {
	0, 1, 3, 3, 3, 4, 1, 0, 
	1, 1, 2, 3, 0, 2, 3, 0, 
	0
};

static readonly sbyte[] _Tokenizer_index_offsets =  new sbyte [] {
	0, 0, 4, 11, 18, 24, 32, 36, 
	38, 43, 48, 52, 58, 60, 64, 70, 
	73
};

static readonly sbyte[] _Tokenizer_indicies =  new sbyte [] {
	0, 2, 0, 1, 0, 2, 3, 0, 
	3, 3, 1, 4, 5, 6, 4, 6, 
	6, 1, 7, 3, 7, 3, 3, 1, 
	8, 9, 10, 8, 10, 10, 10, 1, 
	11, 12, 11, 1, 13, 1, 14, 15, 
	16, 14, 1, 17, 18, 19, 17, 1, 
	20, 20, 20, 1, 21, 20, 20, 20, 
	20, 1, 22, 1, 23, 23, 23, 1, 
	21, 23, 23, 23, 23, 1, 24, 25, 
	1, 1, 0
};

static readonly sbyte[] _Tokenizer_trans_targs =  new sbyte [] {
	2, 0, 3, 5, 4, 3, 3, 4, 
	6, 7, 5, 6, 7, 8, 9, 10, 
	13, 9, 10, 13, 11, 15, 16, 14, 
	16, 12
};

static readonly sbyte[] _Tokenizer_trans_actions =  new sbyte [] {
	0, 0, 3, 7, 5, 17, 0, 0, 
	9, 9, 0, 0, 0, 0, 11, 20, 
	20, 0, 13, 13, 0, 0, 1, 0, 
	23, 15
};

static readonly sbyte[] _Tokenizer_eof_actions =  new sbyte [] {
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 15, 
	0
};

const int Tokenizer_start = 1;
const int Tokenizer_first_final = 15;
const int Tokenizer_error = 0;

const int Tokenizer_en_main = 1;


#line 105 "Tokenizer.rl.cs"


      public void Init()
      {
         
#line 197 "tmp/Tokenizer.cs"
	{
	cs = Tokenizer_start;
	}

#line 110 "Tokenizer.rl.cs"
      }

      public List<Token> Tokenize(char[] data, int len)
      {
         if (_tokens == null) {
           _tokens = new List<Token>(128);
         }
         _tokens.Clear();
         _lineNumber = 1; // start at line 1 like most text editors
         _data = data;
         _tokenStart = 0;
         p = 0;
         int pe = len;
         int eof = len;
         
#line 218 "tmp/Tokenizer.cs"
	{
	sbyte _klen;
	sbyte _trans;
	int _acts;
	int _nacts;
	sbyte _keys;

	if ( p == pe )
		goto _test_eof;
	if ( cs == 0 )
		goto _out;
_resume:
	_keys = _Tokenizer_key_offsets[cs];
	_trans = (sbyte)_Tokenizer_index_offsets[cs];

	_klen = _Tokenizer_single_lengths[cs];
	if ( _klen > 0 ) {
		sbyte _lower = _keys;
		sbyte _mid;
		sbyte _upper = (sbyte) (_keys + _klen - 1);
		while (true) {
			if ( _upper < _lower )
				break;

			_mid = (sbyte) (_lower + ((_upper-_lower) >> 1));
			if ( data[p] < _Tokenizer_trans_keys[_mid] )
				_upper = (sbyte) (_mid - 1);
			else if ( data[p] > _Tokenizer_trans_keys[_mid] )
				_lower = (sbyte) (_mid + 1);
			else {
				_trans += (sbyte) (_mid - _keys);
				goto _match;
			}
		}
		_keys += (sbyte) _klen;
		_trans += (sbyte) _klen;
	}

	_klen = _Tokenizer_range_lengths[cs];
	if ( _klen > 0 ) {
		sbyte _lower = _keys;
		sbyte _mid;
		sbyte _upper = (sbyte) (_keys + (_klen<<1) - 2);
		while (true) {
			if ( _upper < _lower )
				break;

			_mid = (sbyte) (_lower + (((_upper-_lower) >> 1) & ~1));
			if ( data[p] < _Tokenizer_trans_keys[_mid] )
				_upper = (sbyte) (_mid - 2);
			else if ( data[p] > _Tokenizer_trans_keys[_mid+1] )
				_lower = (sbyte) (_mid + 2);
			else {
				_trans += (sbyte)((_mid - _keys)>>1);
				goto _match;
			}
		}
		_trans += (sbyte) _klen;
	}

_match:
	_trans = (sbyte)_Tokenizer_indicies[_trans];
	cs = _Tokenizer_trans_targs[_trans];

	if ( _Tokenizer_trans_actions[_trans] == 0 )
		goto _again;

	_acts = _Tokenizer_trans_actions[_trans];
	_nacts = _Tokenizer_actions[_acts++];
	while ( _nacts-- > 0 )
	{
		switch ( _Tokenizer_actions[_acts++] )
		{
	case 0:
#line 4 "TokenizerDef.rl"
	{ _lineNumber++; log("newline"); EmitNewLine(); }
	break;
	case 1:
#line 5 "TokenizerDef.rl"
	{ log("startKeyword"); StartToken(); }
	break;
	case 2:
#line 6 "TokenizerDef.rl"
	{ logEnd("endKeyword"); EmitToken(TokenType.Keyword); }
	break;
	case 3:
#line 7 "TokenizerDef.rl"
	{ log("startId"); StartToken(); }
	break;
	case 4:
#line 8 "TokenizerDef.rl"
	{ logEnd("endId"); EmitToken(TokenType.Identifier); }
	break;
	case 5:
#line 9 "TokenizerDef.rl"
	{ log("emit tx op"); EmitOperator(TokenOperator.Transition); }
	break;
	case 6:
#line 10 "TokenizerDef.rl"
	{ log("startTransitionValue"); StartToken(); }
	break;
	case 7:
#line 11 "TokenizerDef.rl"
	{ logEnd("endTransitionValue"); EmitToken(TokenType.TransitionValue); }
	break;
#line 324 "tmp/Tokenizer.cs"
		default: break;
		}
	}

_again:
	if ( cs == 0 )
		goto _out;
	if ( ++p != pe )
		goto _resume;
	_test_eof: {}
	if ( p == eof )
	{
	int __acts = _Tokenizer_eof_actions[cs];
	int __nacts = _Tokenizer_actions[__acts++];
	while ( __nacts-- > 0 ) {
		switch ( _Tokenizer_actions[__acts++] ) {
	case 7:
#line 11 "TokenizerDef.rl"
	{ logEnd("endTransitionValue"); EmitToken(TokenType.TransitionValue); }
	break;
#line 345 "tmp/Tokenizer.cs"
		default: break;
		}
	}
	}

	_out: {}
	}

#line 125 "Tokenizer.rl.cs"
         return _tokens;
      }

      public bool Finish()
      {
         return (cs >= Tokenizer_first_final);
      }
   }
}