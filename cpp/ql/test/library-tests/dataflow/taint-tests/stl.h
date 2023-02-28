
typedef unsigned long size_t;

// --- string ---

namespace std
{
	template<class charT> struct char_traits;

	typedef size_t streamsize;

	struct ptrdiff_t;

	template <class iterator_category,
			  class value_type,
			  class difference_type = ptrdiff_t,
			  class pointer_type = value_type*,
			  class reference_type = value_type&>
	struct iterator {
		iterator &operator++();
		iterator operator++(int);
		bool operator==(iterator other) const;
		bool operator!=(iterator other) const;
		reference_type operator*() const;
	};

	struct input_iterator_tag {};
	struct forward_iterator_tag : public input_iterator_tag {};
	struct bidirectional_iterator_tag : public forward_iterator_tag {};
	struct random_access_iterator_tag : public bidirectional_iterator_tag {};

	template <class T> class allocator {
	public:
		allocator() throw();
		typedef size_t size_type;
	};
	
	template<class charT, class traits = char_traits<charT>, class Allocator = allocator<charT> >
	class basic_string {
	public:
		typedef typename Allocator::size_type size_type;

		explicit basic_string(const Allocator& a = Allocator());
		basic_string(const charT* s, const Allocator& a = Allocator());

		const charT* c_str() const;

		typedef std::iterator<random_access_iterator_tag, charT> iterator;
		typedef std::iterator<random_access_iterator_tag, const charT> const_iterator;

		iterator begin();
		iterator end();
		const_iterator begin() const;
		const_iterator end() const;
		const_iterator cbegin() const;
		const_iterator cend() const;

		template<class T> basic_string& operator+=(const T& t);
		basic_string& operator+=(const charT* s);
		basic_string& append(const basic_string& str);
		basic_string& append(const charT* s);
		basic_string& append(size_type n, charT c);
	};

	template<class charT, class traits, class Allocator> basic_string<charT, traits, Allocator> operator+(const basic_string<charT, traits, Allocator>& lhs, const basic_string<charT, traits, Allocator>& rhs);
	template<class charT, class traits, class Allocator> basic_string<charT, traits, Allocator> operator+(const basic_string<charT, traits, Allocator>& lhs, const charT* rhs);

	typedef basic_string<char> string;

	template <class charT, class traits = char_traits<charT> >
	class basic_istream /*: virtual public basic_ios<charT,traits> - not needed for this test */ {
	public:
		basic_istream<charT,traits>& operator>>(int& n);
	};

	template <class charT, class traits = char_traits<charT> >
	class basic_ostream /*: virtual public basic_ios<charT,traits> - not needed for this test */ {
	public:
		typedef charT char_type;
		basic_ostream<charT,traits>& write(const char_type* s, streamsize n);

		basic_ostream<charT, traits>& operator<<(int n);
	};

	template<class charT, class traits> basic_ostream<charT,traits>& operator<<(basic_ostream<charT,traits>&, const charT*);
	template<class charT, class traits, class Allocator> basic_ostream<charT, traits>& operator<<(basic_ostream<charT, traits>& os, const basic_string<charT, traits, Allocator>& str); 

	template<class charT, class traits = char_traits<charT>>
	class basic_iostream : public basic_istream<charT, traits>, public basic_ostream<charT, traits> {
	public:
	};

	template<class charT, class traits = char_traits<charT>, class Allocator = allocator<charT>>
	class basic_stringstream : public basic_iostream<charT, traits> {
	public:
		explicit basic_stringstream(/*ios_base::openmode which = ios_base::out|ios_base::in - not needed for this test*/);

		basic_string<charT, traits, Allocator> str() const;
	};

	using stringstream = basic_stringstream<char>;
}

// --- vector ---

namespace std {
	template <class T>
	class vector {
	private:
		void *data_;
	public:
		vector(int size);

		T& operator[](int idx);
		const T& operator[](int idx) const;

		typedef std::iterator<random_access_iterator_tag, T> iterator;
		typedef std::iterator<random_access_iterator_tag, const T> const_iterator;

		iterator begin() noexcept;
		iterator end() noexcept;

		const_iterator begin() const noexcept;
		const_iterator end() const noexcept;
	};
}
