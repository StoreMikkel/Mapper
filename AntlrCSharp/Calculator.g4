grammar Calculator;

/* Parser Rules */
input          : calculation+ EOF;

calculation    : expression NEWLINE;

expression     : term
               | expression OPERATOR1 term;

term           : factor
               | term OPERATOR2 factor;

factor         : number
               | '(' expression ')';

number         : NUMBER;
/*Lexer Rules*/
NUMBER        : [0-9]+ ;
OPERATOR1      : ('+' | '-' ) ;
OPERATOR2       :( '/' | '*');
WHITESPACE    : (' '|'\t')+ -> skip;
NEWLINE       : ('\r'? '\n' | '\r')+ ;