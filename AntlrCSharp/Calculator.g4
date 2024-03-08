grammar Calculator;

/*Parser Rules*/

input       : calculation EOF;
calculation : expression NEWLINE;
expression  : term | expression operator number;
term        : term operator number | number;
number      : NUMBER ;
operator    : OPERATOR ;

/*Lexer Rules*/

NUMBER        : [0-9]+ ;
OPERATOR      : ('+' | '-' | '/' | '*') ;
WHITESPACE    : (' '|'\t')+ -> skip;
NEWLINE       : ('\r'? '\n' | '\r')+ ;