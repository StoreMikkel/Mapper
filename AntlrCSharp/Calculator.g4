grammar Calculator;

/* Parser Rules */
input          : statement+ EOF;
statement      : ifStatement | calculation;
ifStatement    : IF LPAREN condition RPAREN NEWLINE TAB statement (ELSE NEWLINE TAB statement)?;
condition      : expression LOGOPERATOR expression;
calculation    : expression NEWLINE;
expression     : term | expression OPERATOR1 term;
term           : factor | term OPERATOR2 factor;
factor         : number | '(' expression ')';
number         : NUMBER;
/*Lexer Rules*/
NUMBER        : [0-9]+ ;
OPERATOR1      : ('+' | '-' ) ;
OPERATOR2       :( '/' | '*');
LOGOPERATOR   : ('==' | '>=' | '<='| '!=' | '<' | '>');
WHITESPACE    : (' ')+ -> skip;
NEWLINE       : ('\r'? '\n' | '\r')+ ;
LPAREN        : '(';
RPAREN        : ')';
IF            : ('if');
ELSE          : ('else');
TAB           :('\t');
