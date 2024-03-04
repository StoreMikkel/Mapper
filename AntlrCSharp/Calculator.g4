grammar Calculator;

/*Parser Rules*/

input       : calculation* EOF ;
calculation : number operator number NEWLINE;
number      : NUMBER ;
operator    : OPERATOR ;

/*Lexer Rules*/

NUMBER        : [0-9]+ ;
OPERATOR      : ('+' | '-' | '/' | '*') ;
WHITESPACE    : (' '|'\t')+ -> skip;
NEWLINE       : ('\r'? '\n' | '\r')+ ;