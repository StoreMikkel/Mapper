grammar Calculator;

/*Parser Rules*/

input       : calculation EOF ;
calculation : expression;
expression  : term | expression OPERATOR term;
term        : number OPERATOR number;
number      : NUMBER ;
operator    : OPERATOR ;

/*Lexer Rules*/

NUMBER        : [0-9]+ ;
OPERATOR      : ('+' | '-' | '/' | '*') ;
WHITESPACE    : (' '|'\t')+ -> skip;
NEWLINE       : ('\r'? '\n' | '\r')+ ;