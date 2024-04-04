grammar Calculator;

/* Parser Rules */
input            : statement+ EOF;

statement        : calculation 
                 | ifStatement
                 | whileStatement
                 | variableDeclaration
                 | variableAssignment
                 | forLoop
                 | crementer
                 | arrayDeclaration 
                 | arrayDeclaration2d
                 | arrayAssignement
                 | arrayAccess
                 | arrayAssignment2d
                 | arrayAccess2d;

calculation      : expression (NEWLINE)?;

expression       : term
                 | expression OPERATOR1 term
                 | expression COMPARISON_OPERATOR term
                 | IDENTIFIER
                 | STRING_LITERAL // Added comparison operator
                 | BOOLEAN_LITERAL
                 | arrayAccess
                 | arrayAccess2d;

term             : factor
                 | term OPERATOR2 factor
                 | IDENTIFIER
                 | STRING_LITERAL
                 | BOOLEAN_LITERAL
                 | arrayAccess
                 | arrayAccess2d;

factor           : number
                 | '(' expression ')'
                 | IDENTIFIER
                 | STRING_LITERAL
                 | BOOLEAN_LITERAL
                 | arrayAccess
                 | arrayAccess2d;

number           : NUMBER;

ifStatement      : 'if' '(' expression ')' '{' statement+ '}' (ELSE '{' statement+ '}' NEWLINE)?; // Adjusted ifStatement rule

condition        : '(' expression ')';

whileStatement   : 'while' condition '{' statement* '}';

variableDeclaration : TYPE IDENTIFIER '=' expression (NEWLINE)?;

variableAssignment : IDENTIFIER '=' expression (NEWLINE)?;

forLoop            : 'for' '(' variableDeclaration ';' compare ';' crementer ')' '{' NEWLINE statement+ '}';
crementer          : IDENTIFIER INCREMENTER | IDENTIFIER DECREMENTER;
compare            : expression COMPARISON_OPERATOR term;

arrayDeclaration   : TYPE IDENTIFIER LEFTARRAYBRACKET RIGHTARRAYBRACKET '=' LEFTCURLYBRACKET (expression (',' expression)*)? RIGHTCURLYBRACKET NEWLINE;
arrayAssignement   : IDENTIFIER LEFTARRAYBRACKET number RIGHTARRAYBRACKET '=' expression NEWLINE;
arrayAccess        : IDENTIFIER LEFTARRAYBRACKET number RIGHTARRAYBRACKET (NEWLINE)?;
arrayDeclaration2d : TYPE IDENTIFIER LEFTARRAYBRACKET number ',' number RIGHTARRAYBRACKET ('=' '{' LEFTCURLYBRACKET (expression (',' expression)*)? RIGHTCURLYBRACKET (',' LEFTCURLYBRACKET (expression (',' expression)*)? RIGHTCURLYBRACKET)* '}' )?(NEWLINE)?;
arrayAssignment2d  : IDENTIFIER LEFTARRAYBRACKET number ',' number RIGHTARRAYBRACKET '=' expression (NEWLINE)?;
arrayAccess2d      : IDENTIFIER LEFTARRAYBRACKET number ',' number RIGHTARRAYBRACKET (NEWLINE)?;
/* Lexer Rules */
NUMBER           : [0-9]+ ;
OPERATOR1        : ('+' | '-' ) ;
OPERATOR2        : ('/' | '*');
COMPARISON_OPERATOR: ('>' | '<' | '==' | '!=' | '>=' | '<='); // Added comparison operators
BOOLEAN_LITERAL  : ('true'|'false');
EQUALS           : '=';
LEFTARRAYBRACKET : '[';
RIGHTARRAYBRACKET : ']';
LEFTCURLYBRACKET : '{';
RIGHTCURLYBRACKET: '}';
IDENTIFIER       : [a-zA-Z][a-zA-Z0-9]*;
INCREMENTER      : '++';
DECREMENTER      : '--';
WHITESPACE       : (' '|'\t')+ -> skip;
NEWLINE          : ('\n'| '\r')+;
STRING_LITERAL   : '"' ( ~["\\\r\n] | '\\' . )* '"';

/*TYPE declarations */
TYPE             : ('int '|'double '|'string ' | 'boolean ');
ELSE             : 'else ';