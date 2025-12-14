wordlist = open('/usr/share/dict/words').read().lower().split()
print("The number of words in the English dictionary is:", len(wordlist))

# O(n)
def palindromes(words):
    pal=[] #1
    for w in words: #O(n)
        if w == w[::-1]: #O(len(w)) but words are short so O(1)
            pal.append(w) #O(1)
    return set(pal) #O(n)

# O(n^2)
def ananim(words):
    ana=[]  #1
    for w in words: #O(n)
        if w[::-1] in words: #O(n) using "in", i.e. searchig in a list is O(n)
            ana.append(w) #O(1)
    return ana

#O(n)
def ananim_via_sets(words):
    ana=[] #1
    swords=set(words)  #O(n) conversion to a set take linear time
    for w in swords: #O(n)
        if w[::-1] in swords: #O(1) searchin in a set is const time 
            ana.append(w) #O(1)
    return ana #1

#main

#pal=palindromes(wordlist)
ana=ananim_via_sets(wordlist) 
print(ana[:10])
# very slow
# ana=ananim(wordlist) 

