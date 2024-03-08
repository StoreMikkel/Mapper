grammar Calculator;

/*Parser Rules*/
input: calculation+ EOF;

calculation: expression NEWLINE;

expression: term
          | expression OPERATOR term;

term: number
    | term OPERATOR number;

number: NUMBER;

/*Lexer Rules*/
NUMBER        : [0-9]+ ;
OPERATOR      : ('+' | '-' | '/' | '*') ;
WHITESPACE    : (' '|'\t')+ -> skip;
NEWLINE       : ('\r'? '\n' | '\r')+ ;