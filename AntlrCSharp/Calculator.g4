grammar Calculator;

/* Parser Rules */
input            : statement+ EOF;

statement        : calculation 
                 | ifStatement
                 | whileStatement;

calculation      : expression NEWLINE;

expression       : term
                 | expression OPERATOR1 term
                 | expression COMPARISON_OPERATOR term; // Added comparison operator

term             : factor
                 | term OPERATOR2 factor;

factor           : number
                 | '(' expression ')';

number           : NUMBER;

ifStatement      : 'if' '(' expression ')' '{' statement+ '}' ('else' '{' statement+ '}')?; // Adjusted ifStatement rule

condition        : '(' expression ')';

whileStatement   : 'while' condition '{' statement* '}';

/* Lexer Rules */
NUMBER           : [0-9]+ ;
OPERATOR1        : ('+' | '-' ) ;
OPERATOR2        : ('/' | '*');
COMPARISON_OPERATOR: ('>' | '<' | '==' | '!=' | '>=' | '<='); // Added comparison operators
IDENTIFIER       : [a-zA-Z][a-zA-Z0-9]*;
WHITESPACE       : (' '|'\t')+ -> skip;
NEWLINE          : ('\r'? '\n' | '\r')+ ;