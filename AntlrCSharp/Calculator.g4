grammar Calculator;

/* Parser Rules */
input            : statement+ EOF;

statement        : calculation 
                 | ifStatement
                 | whileStatement
                 | variableDeclaration
                 | variableAssignment;

calculation      : expression NEWLINE;

expression       : term
                 | expression OPERATOR1 term
                 | expression COMPARISON_OPERATOR term
                 | IDENTIFIER
                 | STRING_LITERAL; // Added comparison operator

term             : factor
                 | term OPERATOR2 factor
                 | IDENTIFIER
                 | STRING_LITERAL;

factor           : number
                 | '(' expression ')'
                 | IDENTIFIER
                 | STRING_LITERAL;

number           : NUMBER;

ifStatement      : 'if' '(' expression ')' '{' statement+ '}' ('else' '{' statement+ '}')?; // Adjusted ifStatement rule

condition        : '(' expression ')';

whileStatement   : 'while' condition '{' statement* '}';

variableDeclaration : TYPE IDENTIFIER '=' expression NEWLINE;

variableAssignment : IDENTIFIER '=' expression NEWLINE;

/* Lexer Rules */
NUMBER           : [0-9]+ ;
OPERATOR1        : ('+' | '-' ) ;
OPERATOR2        : ('/' | '*');
COMPARISON_OPERATOR: ('>' | '<' | '==' | '!=' | '>=' | '<='); // Added comparison operators
IDENTIFIER       : [a-zA-Z][a-zA-Z0-9]*;
WHITESPACE       : (' '|'\t')+ -> skip;
NEWLINE          : ('\n'| '\r')+;
STRING_LITERAL   : '"' ( ~["\\\r\n] | '\\' . )* '"';
/*TYPE declarations */
TYPE             : ('int '|'double '|'string ');