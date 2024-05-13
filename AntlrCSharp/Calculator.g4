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
                 | arrayAccess2d
                 | breakStatement
                 | fileWriteStatement
                 | fileWriteNewline
                 | mapDeclaration
                 | mapAccess
                 | mapModification;

calculation      : expression;

expression       : term
                 | expression OPERATOR1 term
                 | expression COMPARISON_OPERATOR term
                 | IDENTIFIER
                 | STRING_LITERAL // Added comparison operator
                 | BOOLEAN_LITERAL
                 | CHARACTER_LITERAL
                 | arrayAccess
                 | arrayAccess2d
                 | randomStatement
                 | mapAccess;

term             : factor
                 | term OPERATOR2 factor
                 | IDENTIFIER
                 | STRING_LITERAL
                 | BOOLEAN_LITERAL
                 | CHARACTER_LITERAL
                 | arrayAccess
                 | arrayAccess2d
                 | randomStatement
                 | mapAccess;

factor           : number
                 | '(' expression ')'
                 | IDENTIFIER
                 | STRING_LITERAL
                 | BOOLEAN_LITERAL
                 | CHARACTER_LITERAL
                 | arrayAccess
                 | arrayAccess2d
                 | randomStatement
                 | mapAccess;

number           : NUMBER;

ifStatement      : 'if' '(' expression (BOOLEANOPERATORS expression)* ')' '{'  statement+ '}'  (ELSE '{' statement+ '}')?; // Adjusted ifStatement rule

whileStatement   : 'while' '(' expression ')' '{' statement+ '}' ;

variableDeclaration : TYPE IDENTIFIER '=' expression;

variableAssignment : IDENTIFIER '=' expression;

forLoop            : 'for' '(' variableDeclaration ';' compare ';' crementer ')' '{' statement+ '}';
crementer          : IDENTIFIER INCREMENTER| IDENTIFIER DECREMENTER;
compare            : expression COMPARISON_OPERATOR term;

arrayDeclaration   : TYPE IDENTIFIER LEFTARRAYBRACKET RIGHTARRAYBRACKET '=' LEFTCURLYBRACKET (expression (',' expression)*)? RIGHTCURLYBRACKET;
arrayAssignement   : IDENTIFIER LEFTARRAYBRACKET (number|IDENTIFIER) RIGHTARRAYBRACKET '=' expression;
arrayAccess        : IDENTIFIER LEFTARRAYBRACKET (number|IDENTIFIER) RIGHTARRAYBRACKET;
arrayDeclaration2d : TYPE IDENTIFIER LEFTARRAYBRACKET (number|IDENTIFIER) ',' (number|IDENTIFIER) RIGHTARRAYBRACKET ('=' '{' LEFTCURLYBRACKET (expression (',' expression)*)? RIGHTCURLYBRACKET (',' LEFTCURLYBRACKET (expression (',' expression)*)? RIGHTCURLYBRACKET)* '}' )?;
arrayAssignment2d  : IDENTIFIER LEFTARRAYBRACKET (number|IDENTIFIER) ',' (number|IDENTIFIER) RIGHTARRAYBRACKET '=' expression;
arrayAccess2d      : IDENTIFIER LEFTARRAYBRACKET (number|IDENTIFIER) ',' (number|IDENTIFIER) RIGHTARRAYBRACKET;
breakStatement     : BREAK;
randomStatement    : RANDOM '(' (number|expression) ',' (number|expression) ')';
fileWriteStatement : 'fileWrite' '(' (arrayAccess2d|CHARACTER_LITERAL) ',' STRING_LITERAL ')';
fileWriteNewline   : 'fileWriteNewline' '(' STRING_LITERAL ')';

mapDeclaration     : TYPE IDENTIFIER '(' NUMBER ')' '(' NUMBER ')' '(' NUMBER ')' '=' STRING_LITERAL (',' STRING_LITERAL)*;
mapAccess          : 'access' IDENTIFIER '(' STRING_LITERAL ')';
mapModification    : 'modify' IDENTIFIER '(' STRING_LITERAL ')' '=' IDENTIFIER;

mapBSP             : 'BSP' IDENTIFIER '(' STRING_LITERAL ')' '=' NUMBER;

/* Lexer Rules */
NUMBER           : [0-9]+ ;
OPERATOR1        : ('+' | '-' ) ;
OPERATOR2        : ('/' | '*');
BOOLEANOPERATORS : ('||'| '&&');
COMPARISON_OPERATOR: ('>' | '<' | '==' | '!=' | '>=' | '<='); // Added comparison operators
BOOLEAN_LITERAL  : ('true'|'false');
BREAK            : 'BREAK';
RANDOM           : 'RANDOM';
EQUALS           : '=';
LEFTARRAYBRACKET : '[';
RIGHTARRAYBRACKET : ']';
LEFTCURLYBRACKET : '{';
RIGHTCURLYBRACKET: '}';
IDENTIFIER       : [a-zA-Z][a-zA-Z0-9]*;
INCREMENTER      : '++';
DECREMENTER      : '--';
WHITESPACE       : (' '|'\t')+ -> skip;
NEWLINE          : ('\n'| '\r')+ -> skip;
CHARACTER_LITERAL : '\'' . '\'';
STRING_LITERAL    : '"' ( ~["\\\r\n] | '\\' . )* '"';


/*TYPE declarations */
TYPE             : ('int '|'double '|'string ' | 'boolean '| 'char ' | 'map ');
ELSE             : 'else ';
